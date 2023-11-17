namespace TBot.Core.Telegram;

public class InlineQuery
{
	public string Id { get; set; }
	public User From { get; set; }
	public string Query { get; set; }
	public string Offset { get; set; }
	public string? ChatType { get; set; }
	public Location? Location { get; set; }

	public InlineQuery(
		string id,
		User from,
		string query,
		string offset,
		string? chatType,
		Location? location)
	{
		Id = id;
		From = from;
		Query = query;
		Offset = offset;
		ChatType = chatType;
		Location = location;
	}
}