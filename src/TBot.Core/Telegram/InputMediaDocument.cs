namespace TBot.Core.Telegram;

public class InputMediaDocument
{
	public string Type { get; set; }
	public string Media { get; set; }
	public string? Thumbnail { get; set; }
	public string? Caption { get; set; }
	public string? ParseMode { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public bool? DisableContentTypeDetection { get; set; }

	public InputMediaDocument(
		string type,
		string media,
		string? thumbnail,
		string? caption,
		string? parseMode,
		List<MessageEntity> captionEntities,
		bool? disableContentTypeDetection)
	{
		Type = type;
		Media = media;
		Thumbnail = thumbnail;
		Caption = caption;
		ParseMode = parseMode;
		CaptionEntities = captionEntities;
		DisableContentTypeDetection = disableContentTypeDetection;
	}
}