namespace TBot.Core.Telegram;

public class BotCommandScopeAllChatAdministrators
{
	public string Type { get; set; }

	public BotCommandScopeAllChatAdministrators(string type)
	{
		Type = type;
	}
}