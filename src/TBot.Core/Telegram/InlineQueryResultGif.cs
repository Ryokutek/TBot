namespace TBot.Core.Telegram;

public class InlineQueryResultGif
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string GifUrl { get; set; }
	public int? GifWidth { get; set; }
	public int? GifHeight { get; set; }
	public int? GifDuration { get; set; }
	public string ThumbnailUrl { get; set; }
	public string? ThumbnailMimeType { get; set; }
	public string? Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultGif(
		string type,
		string id,
		string gifUrl,
		int? gifWidth,
		int? gifHeight,
		int? gifDuration,
		string thumbnailUrl,
		string? thumbnailMimeType,
		string? title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		GifUrl = gifUrl;
		GifWidth = gifWidth;
		GifHeight = gifHeight;
		GifDuration = gifDuration;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailMimeType = thumbnailMimeType;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}