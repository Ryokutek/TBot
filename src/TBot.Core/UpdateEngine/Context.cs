using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class Context
{
    public CurrentRequest CurrentRequest { get; private set; }
    public Update Update { get; private set; }

    protected Context(CurrentRequest currentRequest, Update update)
    {
        CurrentRequest = currentRequest;
        Update = update;
    }

    public static Context Create(CurrentRequest currentRequest, Update update)
    {
        return new Context(currentRequest, update);
    }
}