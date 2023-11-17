namespace TBot.Core.Telegram;

public class BotCommandScopeAllGroupChats
{
	public string Type { get; set; }

	public BotCommandScopeAllGroupChats(string type)
	{
		Type = type;
	}
}