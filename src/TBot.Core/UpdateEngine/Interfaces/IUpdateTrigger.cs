namespace TBot.Core.UpdateEngine.Interfaces;

public interface IUpdateTrigger
{
    Type HandlerType { get; }
    ValueTask<bool> CheckAsync(UpdateContext context, CancellationToken ct = default);
}