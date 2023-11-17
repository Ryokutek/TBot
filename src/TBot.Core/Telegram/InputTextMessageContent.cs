namespace TBot.Core.Telegram;

public class InputTextMessageContent
{
	public string MessageText { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> Entities { get; set; }
	public bool? DisableWebPagePreview { get; set; }

	public InputTextMessageContent(
		string messageText,
		string? parseMode,
		List<MessageEntity> entities,
		bool? disableWebPagePreview)
	{
		MessageText = messageText;
		ParseMode = parseMode;
		Entities = entities;
		DisableWebPagePreview = disableWebPagePreview;
	}
}