namespace TBot.Core.Telegram;

public class InlineQueryResultVoice
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string VoiceUrl { get; set; }
	public string Title { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public int? VoiceDuration { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }

	public InlineQueryResultVoice(
		string type,
		string id,
		string voiceUrl,
		string title,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		int? voiceDuration,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent)
	{
		Type = type;
		Id = id;
		VoiceUrl = voiceUrl;
		Title = title;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		VoiceDuration = voiceDuration;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
	}
}