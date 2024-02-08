using TBot.Core.UpdateEngine;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand;

internal class CommandService : UpdatePipeline
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
        if (context.Update.Message!.Text == "/cancel") {
            await _commandStoreService.ClearCommandAsync(context.UserSession);
            return await ExecuteNextAsync(context);
        }
        
        CommandDescriptor commandDescriptor;
        var chatId = context.Update.Message!.From!.Id;
        
        if (await _commandStoreService.IsCommandActiveAsync(chatId)) {
            commandDescriptor = await _commandStoreService.GetCommandDescriptorAsync(chatId);
        }
        else if(_commandFactory.IsCommandExistsByTrigger(context.Update, out var commandRepresentation)) {
            commandDescriptor = CommandDescriptor.CreateNew(commandRepresentation!.CommandIdentifier, commandRepresentation.CommandParts.Count);
        }
        else {
            return await ExecuteNextAsync(context);
        }
        
        var commandContext = new CommandContext(context.UserSession, context.Update);
        var commandContainer = await _commandStoreService.GetCommandContainerAsync(commandContext.UserSession.ChatId);
        
        var executedCommand = await ExecuteCommandAsync(commandDescriptor!, commandContext, commandContainer);

        if (!commandDescriptor.IsCommandComplete()) {
            await _commandStoreService.SaveCommandAsync(context.UserSession, executedCommand.CommandDescriptor);
            await _commandStoreService.SaveCommandContainerAsync(commandContext.UserSession, executedCommand.CommandContainer);
        }
        else {
            await _commandStoreService.ClearCommandAsync(context.UserSession);
        }
        
        return await ExecuteNextAsync(context);
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
            return new ExecuteCommandResult { CommandDescriptor = descriptor, CommandContainer = container };
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
        
        return new ExecuteCommandResult { CommandDescriptor = descriptor, CommandContainer = container };
    }

    private CommandPart GetCommandPart(
        CommandDescriptor descriptor, 
        CommandContext commandContext,
        CommandContainer commandContainer)
    {
        var commandPart = _commandFactory.CreateCommandPart(descriptor.CommandIdentifier, descriptor.PartNumber);
        commandPart.Init(commandContext, commandContainer);
        return commandPart;
    }
}