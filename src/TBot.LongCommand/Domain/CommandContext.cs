using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.LongCommand.Domain;

public class CommandContext : Context
{
    public CommandContext(CurrentRequest currentRequest, Update update) : base(currentRequest, update)
    {
    }
}