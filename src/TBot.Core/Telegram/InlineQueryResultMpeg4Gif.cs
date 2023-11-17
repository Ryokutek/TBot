namespace TBot.Core.Telegram;

public class InlineQueryResultMpeg4Gif
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string Mpeg4Url { get; set; }
	public int? Mpeg4Width { get; set; }
	public int? Mpeg4Height { get; set; }
	public int? Mpeg4Duration { get; set; }
	public string ThumbnailUrl { get; set; }
	public string? ThumbnailMimeType { get; set; }
	public string? Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultMpeg4Gif(
		string type,
		string id,
		string mpeg4Url,
		int? mpeg4Width,
		int? mpeg4Height,
		int? mpeg4Duration,
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
		Mpeg4Url = mpeg4Url;
		Mpeg4Width = mpeg4Width;
		Mpeg4Height = mpeg4Height;
		Mpeg4Duration = mpeg4Duration;
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