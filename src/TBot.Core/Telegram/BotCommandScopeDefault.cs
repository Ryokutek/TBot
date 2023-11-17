namespace TBot.Core.Telegram;

public class BotCommandScopeDefault
{
	public string Type { get; set; }

	public BotCommandScopeDefault(string type)
	{
		Type = type;
	}
}