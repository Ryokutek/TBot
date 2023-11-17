using TBot.Core.Options;

namespace TBot.Core.CallLimiter;

public interface ICallLimiterService
{
    Task WaitAsync(string key, CallLimiterOptions callLimiterOptions);
}