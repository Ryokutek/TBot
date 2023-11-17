namespace TBot.Core.Telegram;

public class KeyboardButtonPollType
{
	public string? Type { get; set; }

	public KeyboardButtonPollType(string? type)
	{
		Type = type;
	}
}