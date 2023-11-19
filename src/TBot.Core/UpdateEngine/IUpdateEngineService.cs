using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public interface IUpdateEngineService
{
    Task StartAsync(Update update);
}