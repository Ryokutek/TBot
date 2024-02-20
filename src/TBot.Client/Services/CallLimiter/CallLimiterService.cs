using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TBot.Core.CallLimiter;
using TBot.Core.ConfigureOptions;
using TBot.Core.Stores;

namespace TBot.Client.Services.CallLimiter;

public class CallLimiterService : ICallLimiterService
{
    private readonly ITBotStore _itBotStore;
    private readonly ILogger<ICallLimiterService>? _logger;
    private ConcurrentDictionary<string, Locker> Lockers { get; } = new ();

    private CallLimiterOptions _callLimiterOptions = null!;
    
    private static string GetCallLimitContextKey (string key) => $"{key}:{nameof(CallLimitContext)}";

    public CallLimiterService(ITBotStore itBotStore, ILogger<ICallLimiterService>? logger = null)
    {
        _logger = logger;
        _itBotStore = itBotStore;
    }

    public async Task WaitAsync(string callLimiterKey, CallLimiterOptions callLimiterOptions)
    {
        _callLimiterOptions = callLimiterOptions;
        Lockers.TryAdd(callLimiterKey, new Locker());
        
        while (true)
        {
            if (!await _itBotStore.LockTakeAsync(callLimiterKey))
            {
                Wait(Lockers[callLimiterKey].LimiterStoreLock, _callLimiterOptions.StoreTimeout);
                continue;
            }
            
            var callLimiterSyncContext = await GetLimiterContextAsync(GetCallLimitContextKey(callLimiterKey));
            try
            {
                if (callLimiterSyncContext.HasNext())
                {
                    callLimiterSyncContext.SaveCall();
                    return;
                }

                var waitInterval = callLimiterSyncContext.GetWaitInterval();
                _logger?.LogDebug("Sending request blocked. WaitInterval: {WaitInterval}. CallLimiterKey: {CallLimiterKey}", waitInterval, callLimiterKey);
                
                Wait(Lockers[callLimiterKey].RequestLock, waitInterval);
                callLimiterSyncContext.Clear();

                _logger?.LogDebug("Sending request unblocked. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, "Error processing call limits. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
            }
            finally
            {
                await UpdateCallLimitContextAsync(GetCallLimitContextKey(callLimiterKey), callLimiterSyncContext);
                await _itBotStore.LockReleaseAsync(callLimiterKey);
                Wake(Lockers[callLimiterKey].LimiterStoreLock);
            }
        }
    }
    
    private async Task<CallLimitContext> GetLimiterContextAsync(string callLimiterKey)
    {
        CallLimitContext callLimitContext;
        
        if (await _itBotStore.ContainsAsync(callLimiterKey))
        {
            callLimitContext = (await _itBotStore.GetAsync<CallLimitContext>(callLimiterKey))!;
        }
        else
        {
            callLimitContext = new CallLimitContext
            {
                MaxCalls = _callLimiterOptions.MaxCalls,
                Interval = _callLimiterOptions.CallsInterval
            };

            await _itBotStore.SetAsync(callLimiterKey, callLimitContext);
            _logger?.LogDebug("Limit synchronization context successfully created. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
        }

        return callLimitContext;
    }

    private Task UpdateCallLimitContextAsync(string callLimiterKey, CallLimitContext callLimitContext)
    {
        return _itBotStore.SetAsync(callLimiterKey, callLimitContext);
    }
    
    private static void Wait(object lockObject, TimeSpan interval)
    {
        lock (lockObject)
        {
            Monitor.Wait(lockObject, interval);
        }
    }

    private static void Wake(object lockObject)
    {
        lock (lockObject) 
        {
            Monitor.PulseAll(lockObject);
        }
    }
}

public class Locker
{
    public readonly object RequestLock = new ();
    public readonly object LimiterStoreLock = new ();
}