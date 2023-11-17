namespace TBot.Core.Telegram;

public class InputMediaAudio
{
	public string Type { get; set; }
	public string Media { get; set; }
	public string? Thumbnail { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public int? Duration { get; set; }
	public string? Performer { get; set; }
	public string? Title { get; set; }

	public InputMediaAudio(
		string type,
		string media,
		string? thumbnail,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		int? duration,
		string? performer,
		string? title)
	{
		Type = type;
		Media = media;
		Thumbnail = thumbnail;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		Duration = duration;
		Performer = performer;
		Title = title;
	}
}