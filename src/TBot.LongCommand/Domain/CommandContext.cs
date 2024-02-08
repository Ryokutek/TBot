using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.LongCommand.Domain;

public class CommandContext : Context
{
    public CommandContext(UserSession userSession, Update update) : base(userSession, update)
    {
    }
}