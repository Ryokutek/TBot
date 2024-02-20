using Microsoft.Extensions.Logging;
using TBot.Core.UpdateEngine;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand;

internal class CommandService : UpdatePipeline
{
    private readonly ILogger<CommandService>? _logger;
    private readonly ICommandFactory _commandFactory;
    private readonly ICommandStoreService _commandStoreService;
    
    public CommandService(
        ILogger<CommandService>? logger,
        ICommandFactory commandFactory,
        ICommandStoreService commandStoreService)
    {
        _logger = logger;
        _commandFactory = commandFactory;
        _commandStoreService = commandStoreService;
    }

    public override async Task<Context> ExecuteAsync(Context context)
    {
        _logger?.LogDebug("Execution LongCommand processing has started.");
        
        if (context.Update.Message!.Text == "/cancel") {
            await _commandStoreService.ClearCommandAsync(context.CurrentRequest);
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
            _logger?.LogDebug("Execution LongCommand processing has skipped.");
            return await ExecuteNextAsync(context);
        }
        
        _logger?.LogDebug("LongCommand found. CommandIdentifier: {CommandIdentifier}. State: {CommandState}. PartNumber: {PartNumber}. TotalParts: {TotalParts}", 
            commandDescriptor.CommandIdentifier, commandDescriptor.State, commandDescriptor.PartNumber, commandDescriptor.TotalParts);
        
        var commandContext = new CommandContext(context.CurrentRequest, context.Update);
        var commandContainer = await _commandStoreService.GetCommandContainerAsync(commandContext.CurrentRequest.FromChatId);
        var executedCommand = await ExecuteCommandAsync(commandDescriptor, commandContext, commandContainer);
        _logger?.LogDebug("LongCommand executed. CommandIdentifier: {CommandIdentifier}", commandDescriptor.CommandIdentifier);
        
        if (!commandDescriptor.IsCommandComplete()) {
            await _commandStoreService.SaveCommandAsync(context.CurrentRequest, executedCommand.CommandDescriptor);
            await _commandStoreService.SaveCommandContainerAsync(commandContext.CurrentRequest, executedCommand.CommandContainer);
            _logger?.LogDebug("LongCommand saved. CommandIdentifier: {CommandIdentifier}. State: {CommandState}. PartNumber: {PartNumber}. TotalParts: {TotalParts}", 
                commandDescriptor.CommandIdentifier, executedCommand.CommandDescriptor.State, executedCommand.CommandDescriptor.PartNumber, executedCommand.CommandDescriptor.TotalParts);
        }
        else {
            await _commandStoreService.ClearCommandAsync(context.CurrentRequest);
            _logger?.LogDebug("LongCommand cleared. CommandIdentifier: {CommandIdentifier}", commandDescriptor.CommandIdentifier);
        }
        
        _logger?.LogDebug("Execution LongCommand processing has completed.");
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