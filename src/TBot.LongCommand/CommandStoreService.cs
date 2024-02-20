using TBot.Core.Stores;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand;

internal class CommandStoreService : ICommandStoreService
{
    private readonly ITBotStore _tBotStore;

    private static string GetKey(long chatId) => $"TBot:Command:{chatId}";
    private static string GetContainerKey(long chatId) => $"TBot:Command:Container:{chatId}";
    
    public CommandStoreService(ITBotStore tBotStore)
    {
        _tBotStore = tBotStore;
    }

    public async Task<bool> IsCommandActiveAsync(long chatId, string? commandIdentifier)
    {
        var isExists = await _tBotStore.ContainsAsync(GetKey(chatId));
        if (!string.IsNullOrEmpty(commandIdentifier))
        {
            return await _tBotStore.ContainsAsync(GetKey(chatId));
        }

        if (isExists)
        {
            var command = await _tBotStore.GetAsync<CommandStoreState>(GetKey(chatId));
            if (command?.CommandIdentifier == commandIdentifier) {
                return true;
            }
        }

        return false;
    }
    
    public async Task<CommandDescriptor> GetCommandDescriptorAsync(long chatId)
    {
        var state = await _tBotStore.GetAsync<CommandStoreState>(GetKey(chatId));
        if (state is null) {
            throw new Exception($"Command state for {chatId} not found");
        }
        
        return CommandDescriptor.Create(state.CommandIdentifier, state.PartNumber, state.TotalParts, state.PartState);
    }

    public Task<CommandContainer?> GetCommandContainerAsync(long chatId)
    {
        return _tBotStore.GetAsync<CommandContainer>(GetContainerKey(chatId));
    }

    public Task SaveCommandAsync(CurrentRequest currentRequest, CommandDescriptor commandDescriptor)
    {
        return _tBotStore.SetAsync(GetKey(currentRequest.FromChatId), CommandStoreState.Create(currentRequest, commandDescriptor));
    }
    
    public Task SaveCommandContainerAsync(CurrentRequest currentRequest, CommandContainer commandContainer)
    {
        return _tBotStore.SetAsync(GetContainerKey(currentRequest.FromChatId), commandContainer);
    }

    public async Task ClearCommandAsync(CurrentRequest currentRequest)
    {
        await _tBotStore.RemoveAsync(GetKey(currentRequest.FromChatId));
        await _tBotStore.RemoveAsync(GetContainerKey(currentRequest.FromChatId));
    }
}