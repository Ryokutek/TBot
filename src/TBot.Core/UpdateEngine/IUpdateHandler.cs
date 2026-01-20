namespace TBot.Core.UpdateEngine;

public interface IUpdateHandler
{
    public Task ExecuteAsync(UpdateContext context);
}