namespace TBot.Core.Telegram;

public class MessageId
{
	public int MessageIdValue { get; set; }

	public MessageId(int messageIdValue)
	{
		MessageIdValue = messageIdValue;
	}
}