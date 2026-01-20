namespace TBot.Core.UpdateEngine;

public interface IUpdateTrigger
{
    Task<(bool, Type)> CheckAsync(UpdateContext context);
}