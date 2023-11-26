using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.CommandProcessor.Models;

public class CommandContext : Context
{
    protected CommandContext(Session session, Update update) : base(session, update)
    {
    }
}