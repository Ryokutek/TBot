using TBot.Core.ConfigureOptions;

namespace TBot.Core.CallLimiter;

public interface ICallLimiterService
{
    Task WaitAsync(string key, CallLimiterOptions callLimiterOptions);
}