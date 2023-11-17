namespace TBot.Core.Telegram;

public class SentWebAppMessage
{
	public string? InlineMessageId { get; set; }

	public SentWebAppMessage(string? inlineMessageId)
	{
		InlineMessageId = inlineMessageId;
	}
}