using TBot.Core.Storages;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Pipeline.LongTermCommand.Interfaces;

namespace TBot.Pipeline.LongTermCommand.Storages;

public class LongTermCommandCacheStore(ITBotCacheStore tBotCacheStore) : ILongTermCommandStore
{
    private static string GetKey(long chatId) => $"TBot:LongTermCommand:{chatId}";

    public Task<bool> IsLongTermCommandExistsAsync(CurrentRequest currentRequest)
    {
        return tBotCacheStore.ContainsAsync(GetKey(currentRequest.FromChatId));
    }

    public Task<Models.LongTermCommand> GetLongTermCommandAsync(CurrentRequest currentRequest)
    {
        return tBotCacheStore.GetAsync<Models.LongTermCommand>(GetKey(currentRequest.FromChatId))!;
    }
    
    public Task SaveLongTermCommandAsync(CurrentRequest currentRequest, Models.LongTermCommand longTermCommand)
    {
        return tBotCacheStore.SetAsync(GetKey(currentRequest.FromChatId), longTermCommand);
    }
    
    public async Task ClearCommandAsync(CurrentRequest currentRequest)
    {
        await tBotCacheStore.RemoveAsync(GetKey(currentRequest.FromChatId));
    }
}