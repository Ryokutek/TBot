using StackExchange.Redis;
using TBot.Core.ConfigureOptions;

namespace TBot.Storage;

public class RedisTBotStorage(RedisOptions redisOption)
{
    private readonly IDatabase _redisDatabase = ConnectionMultiplexer.Connect(redisOption.ToString()).GetDatabase();

    public async Task<bool> LockTakeAsync(string key)
    {
        return await _redisDatabase.LockTakeAsync($"{key}:Lock", key, TimeSpan.FromMinutes(10));
    }

    public Task<bool> LockReleaseAsync(string key)
    {
        return _redisDatabase.LockReleaseAsync($"{key}:Lock", key);
    }
    
    public async Task<T?> GetAsync<T>(string key)
    {
        var value = (await _redisDatabase.StringGetAsync(key)).ToString();
        return string.IsNullOrEmpty(value) ? default : value.ToObject<T>();
    }
    
    public Task SetAsync<T>(string key, T value, TimeSpan? timeToLive = null) 
    {
        return _redisDatabase.StringSetAsync(key, value.ToJson(), timeToLive);
    }
    
    public Task<bool> ContainsAsync(string key) 
    {
        return _redisDatabase.KeyExistsAsync(key);
    }

    public Task RemoveAsync(string key)
    {
        return _redisDatabase.KeyDeleteAsync(key);
    }
}