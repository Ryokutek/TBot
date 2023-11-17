namespace TBot.Core.Telegram;

public class Audio
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int Duration { get; set; }
	public string? Performer { get; set; }
	public string? Title { get; set; }
	public string? FileName { get; set; }
	public string? MimeType { get; set; }
	public int? FileSize { get; set; }
	public PhotoSize? Thumbnail { get; set; }

	public Audio(
		string fileId,
		string fileUniqueId,
		int duration,
		string? performer,
		string? title,
		string? fileName,
		string? mimeType,
		int? fileSize,
		PhotoSize? thumbnail)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Duration = duration;
		Performer = performer;
		Title = title;
		FileName = fileName;
		MimeType = mimeType;
		FileSize = fileSize;
		Thumbnail = thumbnail;
	}
}