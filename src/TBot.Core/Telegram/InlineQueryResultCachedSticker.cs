namespace TBot.Core.Telegram;

public class InlineQueryResultCachedSticker
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string StickerFileId { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedSticker(
		string type,
		string id,
		string stickerFileId,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		StickerFileId = stickerFileId;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}