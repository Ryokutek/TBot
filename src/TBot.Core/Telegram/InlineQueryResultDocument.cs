namespace TBot.Core.Telegram;

public class InlineQueryResultDocument
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public string DocumentUrl { get; set; }
	public string MimeType { get; set; }
	public string? Description { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }
	public string? ThumbnailUrl { get; set; }
	public int? ThumbnailWidth { get; set; }
	public int? ThumbnailHeight { get; set; }

	public InlineQueryResultDocument(
		string type,
		string id,
		string title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		string documentUrl,
		string mimeType,
		string? description,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent,
		string? thumbnailUrl,
		int? thumbnailWidth,
		int? thumbnailHeight)
	{
		Type = type;
		Id = id;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		DocumentUrl = documentUrl;
		MimeType = mimeType;
		Description = description;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailWidth = thumbnailWidth;
		ThumbnailHeight = thumbnailHeight;
	}
}