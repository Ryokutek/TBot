using TBot.Core.UpdateEngine.Interfaces;

namespace TBot.Core.UpdateEngine;

public abstract class AsyncUpdateTrigger<THandler> : IUpdateTrigger
{
    public Type HandlerType => typeof(THandler);
    public abstract ValueTask<bool> CheckAsync(UpdateContext context, CancellationToken cancellationToken = default);
}