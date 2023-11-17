namespace TBot.Core.Telegram;

public class PassportElementErrorUnspecified
{
	public string Source { get; set; }
	public string Type { get; set; }
	public string ElementHash { get; set; }
	public string Message { get; set; }

	public PassportElementErrorUnspecified(
		string source,
		string type,
		string elementHash,
		string message)
	{
		Source = source;
		Type = type;
		ElementHash = elementHash;
		Message = message;
	}
}