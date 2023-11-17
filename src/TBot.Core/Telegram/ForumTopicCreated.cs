namespace TBot.Core.Telegram;

public class ForumTopicCreated
{
	public string Name { get; set; }
	public int IconColor { get; set; }
	public string? IconCustomEmojiId { get; set; }

	public ForumTopicCreated(string name, int iconColor, string? iconCustomEmojiId)
	{
		Name = name;
		IconColor = iconColor;
		IconCustomEmojiId = iconCustomEmojiId;
	}
}