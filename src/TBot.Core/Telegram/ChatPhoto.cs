namespace TBot.Core.Telegram;

public class ChatPhoto
{
	public string SmallFileId { get; set; }
	public string SmallFileUniqueId { get; set; }
	public string BigFileId { get; set; }
	public string BigFileUniqueId { get; set; }

	public ChatPhoto(
		string smallFileId,
		string smallFileUniqueId,
		string bigFileId,
		string bigFileUniqueId)
	{
		SmallFileId = smallFileId;
		SmallFileUniqueId = smallFileUniqueId;
		BigFileId = bigFileId;
		BigFileUniqueId = bigFileUniqueId;
	}
}