namespace TBot.Core.Telegram;

public class Animation
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public int Duration { get; set; }
	public PhotoSize? Thumbnail { get; set; }
	public string? FileName { get; set; }
	public string? MimeType { get; set; }
	public int? FileSize { get; set; }

	public Animation(
		string fileId,
		string fileUniqueId,
		int width,
		int height,
		int duration,
		PhotoSize? thumbnail,
		string? fileName,
		string? mimeType,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Width = width;
		Height = height;
		Duration = duration;
		Thumbnail = thumbnail;
		FileName = fileName;
		MimeType = mimeType;
		FileSize = fileSize;
	}
}