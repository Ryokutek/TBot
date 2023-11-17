namespace TBot.Core.Telegram;

public class VideoNote
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int Length { get; set; }
	public int Duration { get; set; }
	public PhotoSize? Thumbnail { get; set; }
	public int? FileSize { get; set; }

	public VideoNote(
		string fileId,
		string fileUniqueId,
		int length,
		int duration,
		PhotoSize? thumbnail,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Length = length;
		Duration = duration;
		Thumbnail = thumbnail;
		FileSize = fileSize;
	}
}