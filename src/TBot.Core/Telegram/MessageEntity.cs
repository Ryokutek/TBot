namespace TBot.Core.Telegram;

public class MessageEntity
{
	public string Type { get; set; }
	public int Offset { get; set; }
	public int Length { get; set; }
	public string? Url { get; set; }
	public User? User { get; set; }
	public string? Language { get; set; }
	public string? CustomEmojiId { get; set; }

	public MessageEntity(
		string type,
		int offset,
		int length,
		string? url,
		User? user,
		string? language,
		string? customEmojiId)
	{
		Type = type;
		Offset = offset;
		Length = length;
		Url = url;
		User = user;
		Language = language;
		CustomEmojiId = customEmojiId;
	}
}