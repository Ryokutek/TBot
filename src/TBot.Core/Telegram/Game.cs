namespace TBot.Core.Telegram;

public class Game
{
	public string Title { get; set; }
	public string Description { get; set; }
	public List<PhotoSize> Photo { get; set; }
	public string? Text { get; set; }
	public List<MessageEntity> TextEntities { get; set; }
	public Animation? Animation { get; set; }

	public Game(
		string title,
		string description,
		List<PhotoSize> photo,
		string? text,
		List<MessageEntity> textEntities,
		Animation? animation)
	{
		Title = title;
		Description = description;
		Photo = photo;
		Text = text;
		TextEntities = textEntities;
		Animation = animation;
	}
}