using Microsoft.Extensions.Options;
using StackExchange.Redis;
using TBot.Client.Utilities;
using TBot.Core.CallLimiter;
using TBot.Core.Options.CallLimiter.Redis;

namespace TBot.Client.Services.CallLimiter.LimiterStores.Redis;

public class RedisCallLimitStore : ICallLimitStore
{
    private readonly IDatabase _redisDatabase;

    public RedisCallLimitStore(IOptions<RedisOption> redisOption)
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
    
    public async Task<CallLimitContext?> GetAsync(string key)
    {
        string value = (await _redisDatabase.StringGetAsync(key)).ToString();
        return string.IsNullOrEmpty(value) ? default : value.ToObject<CallLimitContext>();
    }
    
    public Task SetAsync(string key, CallLimitContext callLimitContext, TimeSpan? timeToLive = null) 
    {
        return _redisDatabase.StringSetAsync(key, callLimitContext.ToJson(), timeToLive);
    }
    
    public Task<bool> ContainsAsync(string key) 
    {
        return _redisDatabase.KeyExistsAsync(key);
    }
}