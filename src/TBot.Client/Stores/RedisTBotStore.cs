using Microsoft.Extensions.Options;
using StackExchange.Redis;
using TBot.Client.Utilities;
using TBot.Core.CallLimiter;
using TBot.Core.Options;
using TBot.Core.Stores;

namespace TBot.Client.Stores;

public class RedisTBotStore : ITBotStore
{
    private readonly IDatabase _redisDatabase;

    public RedisTBotStore(IOptions<RedisOptions> redisOption)
    {
        _redisDatabase = ConnectionMultiplexer.Connect(redisOption.Value.ToString()).GetDatabase();
    }

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