namespace TBot.Core.Telegram;

public class InlineQueryResultCachedVideo
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string VideoFileId { get; set; }
	public string Title { get; set; }
	public string? Description { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedVideo(
		string type,
		string id,
		string videoFileId,
		string title,
		string? description,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		VideoFileId = videoFileId;
		Title = title;
		Description = description;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}