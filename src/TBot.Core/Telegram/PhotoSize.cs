namespace TBot.Core.Telegram;

public class PhotoSize
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int Width { get; set; }
	public int Height { get; set; }
	public int? FileSize { get; set; }

	public PhotoSize(
		string fileId,
		string fileUniqueId,
		int width,
		int height,
		int? fileSize)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		Width = width;
		Height = height;
		FileSize = fileSize;
	}
}