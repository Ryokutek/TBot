namespace TBot.Core.Telegram;

public class InlineQueryResultPhoto
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string PhotoUrl { get; set; }
	public string ThumbnailUrl { get; set; }
	public int? PhotoWidth { get; set; }
	public int? PhotoHeight { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultPhoto(
		string type,
		string id,
		string photoUrl,
		string thumbnailUrl,
		int? photoWidth,
		int? photoHeight,
		string? title,
		string? description,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		PhotoUrl = photoUrl;
		ThumbnailUrl = thumbnailUrl;
		PhotoWidth = photoWidth;
		PhotoHeight = photoHeight;
		Title = title;
		Description = description;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}