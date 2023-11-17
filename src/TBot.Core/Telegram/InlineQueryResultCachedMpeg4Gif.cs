namespace TBot.Core.Telegram;

public class InlineQueryResultCachedMpeg4Gif
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string Mpeg4FileId { get; set; }
	public string? Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedMpeg4Gif(
		string type,
		string id,
		string mpeg4FileId,
		string? title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		Mpeg4FileId = mpeg4FileId;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}