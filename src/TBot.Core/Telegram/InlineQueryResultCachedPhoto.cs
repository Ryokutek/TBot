namespace TBot.Core.Telegram;

public class InlineQueryResultCachedPhoto
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string PhotoFileId { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedPhoto(
		string type,
		string id,
		string photoFileId,
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
		PhotoFileId = photoFileId;
		Title = title;
		Description = description;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}