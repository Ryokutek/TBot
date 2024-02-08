using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class Context
{
    public UserSession UserSession { get; private set; }
    public Update Update { get; private set; }

    protected Context(UserSession userSession, Update update)
    {
        UserSession = userSession;
        Update = update;
    }

    public static Context Create(UserSession userSession, Update update)
    {
        return new Context(userSession, update);
    }
}