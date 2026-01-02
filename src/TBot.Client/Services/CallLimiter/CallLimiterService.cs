using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using TBot.Core.CallLimiter;
using TBot.Core.CallLimiter.Interfaces;
using TBot.Core.ConfigureOptions;
using TBot.Core.TBot.Interfaces;

namespace TBot.Client.Services.CallLimiter;

public class CallLimiterService(ITBotStore itBotStore, ILogger<ICallLimiterService>? logger = null)
    : ICallLimiterService
{
    private ConcurrentDictionary<string, Locker> Lockers { get; } = new ();

    private CallLimiterOptions _callLimiterOptions = null!;
    
    private static string GetCallLimitContextKey (string key) => $"{key}:{nameof(CallLimitContext)}";

    public async Task WaitAsync(string callLimiterKey, int messageCount, CallLimiterOptions callLimiterOptions)
    {
        _callLimiterOptions = callLimiterOptions;
        Lockers.TryAdd(callLimiterKey, new Locker());
        
        while (true)
        {
            if (!await itBotStore.LockTakeAsync(callLimiterKey))
            {
                Wait(Lockers[callLimiterKey].LimiterStoreLock, _callLimiterOptions.StoreTimeout);
                continue;
            }
            
            var callLimiterSyncContext = await GetLimiterContextAsync(GetCallLimitContextKey(callLimiterKey));
            try
            {
                if (callLimiterSyncContext.HasNext(messageCount))
                {
                    callLimiterSyncContext.SaveCall(messageCount);
                    return;
                }

                var waitInterval = callLimiterSyncContext.GetWaitInterval();
                logger?.LogDebug("Sending request blocked. WaitInterval: {WaitInterval}. CallLimiterKey: {CallLimiterKey}", waitInterval, callLimiterKey);
                
                await UpdateCallLimitContextAsync(GetCallLimitContextKey(callLimiterKey), callLimiterSyncContext);
                Wait(Lockers[callLimiterKey].RequestLock, waitInterval);
                callLimiterSyncContext.Clear();

                logger?.LogDebug("Sending request unblocked. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
            }
            catch (Exception exception)
            {
                logger?.LogError(exception, "Error processing call limits. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
            }
            finally
            {
                await UpdateCallLimitContextAsync(GetCallLimitContextKey(callLimiterKey), callLimiterSyncContext);
                await itBotStore.LockReleaseAsync(callLimiterKey);
                Wake(Lockers[callLimiterKey].LimiterStoreLock);
            }
        }
    }
    
    private async Task<CallLimitContext> GetLimiterContextAsync(string callLimiterKey)
    {
        CallLimitContext callLimitContext;
        
        if (await itBotStore.ContainsAsync(callLimiterKey))
        {
            callLimitContext = (await itBotStore.GetAsync<CallLimitContext>(callLimiterKey))!;
        }
        else
        {
            callLimitContext = new CallLimitContext
            {
                MaxCalls = _callLimiterOptions.MaxCalls,
                Interval = _callLimiterOptions.CallsInterval
            };

            await itBotStore.SetAsync(callLimiterKey, callLimitContext);
            logger?.LogDebug("Limit synchronization context successfully created. CallLimiterKey: {CallLimiterKey}", callLimiterKey);
        }

        return callLimitContext;
    }

    private Task UpdateCallLimitContextAsync(string callLimiterKey, CallLimitContext callLimitContext)
    {
        return itBotStore.SetAsync(callLimiterKey, callLimitContext);
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