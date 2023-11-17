namespace TBot.Core.Telegram;

public class BotCommandScopeAllPrivateChats
{
	public string Type { get; set; }

	public BotCommandScopeAllPrivateChats(string type)
	{
		Type = type;
	}
}