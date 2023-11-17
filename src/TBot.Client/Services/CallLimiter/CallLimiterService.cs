using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TBot.Core.CallLimiter;
using TBot.Core.Options;

namespace TBot.Client.Services.CallLimiter;

public class CallLimiterService : ICallLimiterService
{
    private readonly ICallLimitStore _callLimitStore;
    private readonly ILogger<ICallLimiterService>? _logger;
    private ConcurrentDictionary<string, Locker> Lockers { get; } = new ();

    private CallLimiterOptions _callLimiterOptions = null!;
    
    private static string GetCallLimitContextKey (string key) => $"{key}:{nameof(CallLimitContext)}";

    public CallLimiterService(ICallLimitStore callLimitStore, ILogger<ICallLimiterService>? logger = null)
    {
        _logger = logger;
        _callLimitStore = callLimitStore;
    }

    public async Task WaitAsync(string key, CallLimiterOptions callLimiterOptions)
    {
        _callLimiterOptions = callLimiterOptions;
        Lockers.TryAdd(key, new Locker());
        
        while (true)
        {
            if (!await _callLimitStore.LockTakeAsync(key))
            {
                Wait(Lockers[key].LimiterStoreLock, _callLimiterOptions.StoreTimeout);
                continue;
            }
            
            var callLimiterSyncContext = await GetLimiterContextAsync(GetCallLimitContextKey(key));
            try
            {
                if (callLimiterSyncContext.HasNext())
                {
                    callLimiterSyncContext.SaveCall();
                    return;
                }

                TimeSpan waitInterval = callLimiterSyncContext.GetWaitInterval();
                _logger?.LogDebug("Sending request blocked for {WaitInterval} due to the limit. " +
                                        "Request Key: {Key}", waitInterval, key);
                
                Wait(Lockers[key].RequestLock, waitInterval);
                callLimiterSyncContext.Clear();

                _logger?.LogDebug("Sending request unblocked. Request Key: {Key}", key);
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception, "Error processing limits. Request Key: {Key}", key);
            }
            finally
            {
                await UpdateCallLimitContextAsync(GetCallLimitContextKey(key), callLimiterSyncContext);
                await _callLimitStore.LockReleaseAsync(key);
                Wake(Lockers[key].LimiterStoreLock);
            }
        }
    }
    
    private async Task<CallLimitContext> GetLimiterContextAsync(string key)
    {
        CallLimitContext callLimitContext;
        
        if (await _callLimitStore.ContainsAsync(key))
        {
            callLimitContext = (await _callLimitStore.GetAsync(key))!;
        }
        else
        {
            callLimitContext = new CallLimitContext
            {
                MaxCalls = _callLimiterOptions.MaxCalls,
                Interval = _callLimiterOptions.CallsInterval
            };

            await _callLimitStore.SetAsync(key, callLimitContext);
            _logger?.LogDebug("Limit synchronization context successfully created. Request Key: {Key}", key);
        }

        return callLimitContext;
    }

    private Task UpdateCallLimitContextAsync(string key, CallLimitContext callLimitContext)
    {
        return _callLimitStore.SetAsync(key, callLimitContext);
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