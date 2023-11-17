namespace TBot.Core.Telegram;

public class PassportFile
{
	public string FileId { get; set; }
	public string FileUniqueId { get; set; }
	public int FileSize { get; set; }
	public int FileDate { get; set; }

	public PassportFile(
		string fileId,
		string fileUniqueId,
		int fileSize,
		int fileDate)
	{
		FileId = fileId;
		FileUniqueId = fileUniqueId;
		FileSize = fileSize;
		FileDate = fileDate;
	}
}