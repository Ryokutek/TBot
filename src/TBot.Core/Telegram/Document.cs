namespace TBot.Core.Telegram;

public class Document
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public PhotoSize? Thumbnail { get; set; }
	public string? FileName { get; set; }
	public string? MimeType { get; set; }
	public int? FileSize { get; set; }

	public Document(
		string fileId,
		string fileUniqueId,
		PhotoSize? thumbnail,
		string? fileName,
		string? mimeType,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Thumbnail = thumbnail;
		FileName = fileName;
		MimeType = mimeType;
		FileSize = fileSize;
	}
}