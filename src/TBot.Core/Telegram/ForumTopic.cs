namespace TBot.Core.Telegram;

public class ForumTopic
{
	public int MessageThreadId { get; set; }
	public string Name { get; set; }
	public int IconColor { get; set; }
	public string? IconCustomEmojiId { get; set; }

	public ForumTopic(
		int messageThreadId,
		string name,
		int iconColor,
		string? iconCustomEmojiId)
	{
		MessageThreadId = messageThreadId;
		Name = name;
		IconColor = iconColor;
		IconCustomEmojiId = iconCustomEmojiId;
	}
}