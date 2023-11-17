namespace TBot.Core.Telegram;

public class InputMediaPhoto
{
	public string Type { get; set; }
	public string Media { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public bool? HasSpoiler { get; set; }

	public InputMediaPhoto(
		string type,
		string media,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		bool? hasSpoiler)
	{
		Type = type;
		Media = media;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		HasSpoiler = hasSpoiler;
	}
}