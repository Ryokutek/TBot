using TBot.Command.Abstractions;
using TBot.Command.Domain;
using TBot.Command.Interfaces;
using TBot.Core.UpdateEngine;

namespace TBot.Command;

public class CommandService : UpdatePipeline
{
    private readonly ICommandFactory _commandFactory;
    private readonly ICommandStoreService _commandStoreService;
    
    public CommandService(
        ICommandFactory commandFactory,
        ICommandStoreService commandStoreService)
    {
        _commandFactory = commandFactory;
        _commandStoreService = commandStoreService;
    }

    public override async Task<Context> ExecuteAsync(Context context)
    { 
        var commandName = context.Update.Message!.Text!;
        var chatId = context.Update.Message.From!.Id;

        var isCommandActive = await _commandStoreService.IsCommandActiveAsync(chatId);
        if (!_commandFactory.IsCommandExist(commandName) && !isCommandActive)
            return await ExecuteNextAsync(context);
        
        var commandContext = new CommandContext(context.Session, context.Update);
        var commandDescriptor = await GetCommandDescriptorAsync(commandName, chatId);
        var commandContainer = await _commandStoreService.GetCommandContainerAsync(commandContext.Session.ChatId);
        
        var executedCommand = await ExecuteCommandAsync(commandDescriptor, commandContext, commandContainer);

        if (!commandDescriptor.IsCommandComplete()) {
            await _commandStoreService.SaveCommandAsync(context.Session, executedCommand.CommandDescriptor);
            await _commandStoreService.SaveCommandContainerAsync(commandContext.Session, executedCommand.CommandContainer);
        }
        else {
            await _commandStoreService.ClearCommandAsync(context.Session);
        }
        
        return await ExecuteNextAsync(context);
    }

    private async Task<CommandDescriptor> GetCommandDescriptorAsync(string commandName, long chatId)
    {
        CommandDescriptor commandDescriptor;
        if (await _commandStoreService.IsCommandActiveAsync(chatId)) {
            commandDescriptor = await _commandStoreService.GetCommandDescriptorAsync(chatId);
        }
        else {
            commandDescriptor = CommandDescriptor.CreateNew(commandName, _commandFactory.GetTotalParts(commandName));
        }

        return commandDescriptor;
    }

    private async Task<ExecuteCommandResult> ExecuteCommandAsync(
        CommandDescriptor descriptor,
        CommandContext commandContext, 
        CommandContainer? container)
    {
        container ??= new CommandContainer();
        var commandPart = GetCommandPart(descriptor, commandContext, container);

        if (descriptor.State == CommandPartState.Action)
        {
            await commandPart.ExecuteActionRequestAsync();
            descriptor.SetProcessState();
        }

        if (descriptor.State == CommandPartState.Process)
        {
            await commandPart.ExecuteProcessAnswerAsync();
            if (commandPart.IsCommandPartCompleted) {
                descriptor.IncrementPart();
                if (!descriptor.IsCommandComplete()) {
                    return await ExecuteCommandAsync(descriptor, commandContext, container);
                }
            }
        }
        
        return new ExecuteCommandResult
        {
            CommandDescriptor = descriptor,
            CommandContainer = container
        };
    }

    private CommandPart GetCommandPart(
        CommandDescriptor descriptor, 
        CommandContext commandContext,
        CommandContainer commandContainer)
    {
        var commandPart = _commandFactory.CreateCommandPart(descriptor.Name, descriptor.PartNumber);
        commandPart.Init(commandContext, commandContainer);
        return commandPart;
    }
}