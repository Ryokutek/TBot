namespace TBot.Core.Telegram;

public class InlineQueryResultGame
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string GameShortName { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }

	public InlineQueryResultGame(
		string type,
		string id,
		string gameShortName,
		InlineKeyboardMarkup? replyMarkup)
	{
		Type = type;
		Id = id;
		GameShortName = gameShortName;
		ReplyMarkup = replyMarkup;
	}
}