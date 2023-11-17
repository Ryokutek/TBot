namespace TBot.Core.Telegram;

public class BotCommandScopeChatAdministrators
{
	public string Type { get; set; }
	public ChatIdentifier ChatId { get; set; }

	public BotCommandScopeChatAdministrators(string type, ChatIdentifier chatId)
	{
		Type = type;
		ChatId = chatId;
	}
}