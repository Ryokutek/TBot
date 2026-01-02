using TBot.Core.ConfigureOptions;

namespace TBot.Core.CallLimiter.Interfaces;

public interface ICallLimiterService
{
    Task WaitAsync(string callLimiterKey, int messageCount, CallLimiterOptions callLimiterOptions);
}