using TBot.Core.Telegram;

namespace TBot.Core.LongPolling;

public interface ILongPollingService
{
    void Start(Func<Update, Task> updateAction, CancellationToken? cancellationToken = null);
}