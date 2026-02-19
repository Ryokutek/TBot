using TBot.Core.UpdateEngine.Interfaces;

namespace TBot.Core.UpdateEngine;

public abstract class SyncUpdateTrigger<THandler> : IUpdateTrigger
{
    public Type HandlerType => typeof(THandler);
    protected abstract bool Check(UpdateContext context);

    public ValueTask<bool> CheckAsync(UpdateContext context, CancellationToken ct = default)
        => new(Check(context));
}