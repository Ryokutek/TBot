namespace TBot.Core.Telegram;

public class CallbackQuery
{
	public string Id { get; set; }
	public User From { get; set; }
	public Message? Message { get; set; }
	public string? InlineMessageId { get; set; }
	public string ChatInstance { get; set; }
	public string? Data { get; set; }
	public string? GameShortName { get; set; }

	public CallbackQuery(
		string id,
		User from,
		Message? message,
		string? inlineMessageId,
		string chatInstance,
		string? data,
		string? gameShortName)
	{
		Id = id;
		From = from;
		Message = message;
		InlineMessageId = inlineMessageId;
		ChatInstance = chatInstance;
		Data = data;
		GameShortName = gameShortName;
	}
}