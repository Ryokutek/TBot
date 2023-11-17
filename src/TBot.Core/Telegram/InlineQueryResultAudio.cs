namespace TBot.Core.Telegram;

public class InlineQueryResultAudio
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string AudioUrl { get; set; }
	public string Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public string? Performer { get; set; }
	public int? AudioDuration { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultAudio(
		string type,
		string id,
		string audioUrl,
		string title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		string? performer,
		int? audioDuration,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		AudioUrl = audioUrl;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		Performer = performer;
		AudioDuration = audioDuration;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}