namespace TBot.Core.Telegram;

public class ChatShared
{
	public int RequestId { get; set; }
	public int ChatId { get; set; }

	public ChatShared(int requestId, int chatId)
	{
		RequestId = requestId;
		ChatId = chatId;
	}
}