namespace TBot.Core.Stores;

public interface ITBotStore
{
    Task<bool> LockTakeAsync(string key);
    Task<bool> LockReleaseAsync(string key);
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? timeToLive = null);
    Task<bool> ContainsAsync(string key);
    Task RemoveAsync(string key);
}