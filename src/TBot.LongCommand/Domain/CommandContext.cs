﻿using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.LongCommand.Domain;

public class CommandContext : Context
{
    public CommandContext(Session session, Update update) : base(session, update)
    {
    }
}