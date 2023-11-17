namespace TBot.Core.Telegram;

public class Voice
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int Duration { get; set; }
	public string? MimeType { get; set; }
	public int? FileSize { get; set; }

	public Voice(
		string fileId,
		string fileUniqueId,
		int duration,
		string? mimeType,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Duration = duration;
		MimeType = mimeType;
		FileSize = fileSize;
	}
}