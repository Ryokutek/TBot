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
        if (context.Update.Message!.Text == "/cancel")
        {
            await _commandStoreService.ClearCommandAsync(context.Session);
            return await ExecuteNextAsync(context);
        }
        
        var chatId = context.Update.Message!.From!.Id;

        CommandDescriptor? commandDescriptor = null;
        if (!_commandFactory.TryGetCommandByTrigger(context.Update, out var commandRepresentation))
        {
            if (await _commandStoreService.IsCommandActiveAsync(chatId))
            {
                commandDescriptor = await GetCommandDescriptorAsync(commandRepresentation!, chatId);
                if (!_commandFactory.TryGetCommandByIdentifier(commandDescriptor.CommandIdentifier, out commandRepresentation))
                { 
                    return await ExecuteNextAsync(context);
                }
            }
        }
        
        var commandContext = new CommandContext(context.Session, context.Update);
        var commandContainer = await _commandStoreService.GetCommandContainerAsync(commandContext.Session.ChatId);
        
        var executedCommand = await ExecuteCommandAsync(commandRepresentation!, commandDescriptor!, commandContext, commandContainer);

        if (!commandDescriptor!.IsCommandComplete()) {
            await _commandStoreService.SaveCommandAsync(context.Session, executedCommand.CommandDescriptor);
            await _commandStoreService.SaveCommandContainerAsync(commandContext.Session, executedCommand.CommandContainer);
        }
        else {
            await _commandStoreService.ClearCommandAsync(context.Session);
        }
        
        return await ExecuteNextAsync(context);
    }

    private async Task<CommandDescriptor> GetCommandDescriptorAsync(CommandRepresentation commandRepresentation, long chatId)
    {
        CommandDescriptor commandDescriptor;
        if (await _commandStoreService.IsCommandActiveAsync(chatId)) {
            commandDescriptor = await _commandStoreService.GetCommandDescriptorAsync(chatId);
        }
        else {
            commandDescriptor = CommandDescriptor.CreateNew(commandRepresentation.CommandIdentifier, commandRepresentation.CommandParts.Count);
        }

        return commandDescriptor;
    }

    private async Task<ExecuteCommandResult> ExecuteCommandAsync(
        CommandRepresentation commandRepresentation,
        CommandDescriptor descriptor,
        CommandContext commandContext, 
        CommandContainer? container)
    {
        container ??= new CommandContainer();
        var commandPart = GetCommandPart(commandRepresentation, descriptor, commandContext, container);
        
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
                    return await ExecuteCommandAsync(commandRepresentation, descriptor, commandContext, container);
                }
            }
        }
        
        return new ExecuteCommandResult { CommandDescriptor = descriptor, CommandContainer = container };
    }

    private CommandPart GetCommandPart(
        CommandRepresentation commandRepresentation,
        CommandDescriptor descriptor, 
        CommandContext commandContext,
        CommandContainer commandContainer)
    {
        var commandPart = _commandFactory.CreateCommandPart(commandRepresentation, descriptor.PartNumber);
        commandPart.Init(commandContext, commandContainer);
        return commandPart;
    }
}