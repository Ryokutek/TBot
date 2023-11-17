namespace TBot.Core.Telegram;

public class InlineQueryResultCachedDocument
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string Title { get; set; }
	public string DocumentFileId { get; set; }
	public string? Description { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedDocument(
		string type,
		string id,
		string title,
		string documentFileId,
		string? description,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		Title = title;
		DocumentFileId = documentFileId;
		Description = description;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}