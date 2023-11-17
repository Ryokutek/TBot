namespace TBot.Core.Telegram;

public class BotCommandScopeChat
{
	public string Type { get; set; }
	public ChatIdentifier ChatId { get; set; }

	public BotCommandScopeChat(string type, ChatIdentifier chatId)
	{
		Type = type;
		ChatId = chatId;
	}
}