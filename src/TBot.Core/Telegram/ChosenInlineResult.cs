namespace TBot.Core.Telegram;

public class ChosenInlineResult
{
	public string ResultId { get; set; }
	public User From { get; set; }
	public Location? Location { get; set; }
	public string? InlineMessageId { get; set; }
	public string Query { get; set; }

	public ChosenInlineResult(
		string resultId,
		User from,
		Location? location,
		string? inlineMessageId,
		string query)
	{
		ResultId = resultId;
		From = from;
		Location = location;
		InlineMessageId = inlineMessageId;
		Query = query;
	}
}