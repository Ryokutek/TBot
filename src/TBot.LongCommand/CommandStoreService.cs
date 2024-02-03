using TBot.Core.Stores;
using TBot.Core.TBot.RequestIdentification;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand;

public class CommandStoreService : ICommandStoreService
{
    private readonly ITBotStore _tBotStore;

    private static string GetKey(long chatId) => $"TBot:Command:{chatId}";
    private static string GetContainerKey(long chatId) => $"TBot:Command:Container:{chatId}";
    
    public CommandStoreService(ITBotStore tBotStore)
    {
        _tBotStore = tBotStore;
    }

    public Task<bool> IsCommandActiveAsync(long chatId)
    {
        return _tBotStore.ContainsAsync(GetKey(chatId));
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

    public Task SaveCommandAsync(Session session, CommandDescriptor commandDescriptor)
    {
        return _tBotStore.SetAsync(GetKey(session.ChatId), CommandStoreState.Create(session, commandDescriptor));
    }
    
    public Task SaveCommandContainerAsync(Session session, CommandContainer commandContainer)
    {
        return _tBotStore.SetAsync(GetContainerKey(session.ChatId), commandContainer);
    }

    public async Task ClearCommandAsync(Session session)
    {
        await _tBotStore.RemoveAsync(GetKey(session.ChatId));
        await _tBotStore.RemoveAsync(GetContainerKey(session.ChatId));
    }
}