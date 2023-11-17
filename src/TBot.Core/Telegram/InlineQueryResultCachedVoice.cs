namespace TBot.Core.Telegram;

public class InlineQueryResultCachedVoice
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string VoiceFileId { get; set; }
	public string Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultCachedVoice(
		string type,
		string id,
		string voiceFileId,
		string title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		VoiceFileId = voiceFileId;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}