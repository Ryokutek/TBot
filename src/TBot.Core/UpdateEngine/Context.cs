using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class Context
{
    public Session Session { get; private set; }
    public Update Update { get; private set; }

    protected Context(Session session, Update update)
    {
        Session = session;
        Update = update;
    }

    public static Context Create(Session session, Update update)
    {
        return new Context(session, update);
    }
}