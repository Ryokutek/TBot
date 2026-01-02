using TBot.Dto.Updates;

namespace TBot.Core.LongPolling.Interfaces;

public interface ILongPollingService
{
    void StartPolling(Func<UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null);
}