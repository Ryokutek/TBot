namespace TBot.Core.UpdateEngine.Interfaces;

public interface IUpdateHandler
{
    public Task ExecuteAsync(UpdateContext context, CancellationToken cancellationToken);
}