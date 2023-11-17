namespace TBot.Core.Telegram;

public class KeyboardButtonRequestUser
{
	public int RequestId { get; set; }
	public bool? UserIsBot { get; set; }
	public bool? UserIsPremium { get; set; }

	public KeyboardButtonRequestUser(int requestId, bool? userIsBot, bool? userIsPremium)
	{
		RequestId = requestId;
		UserIsBot = userIsBot;
		UserIsPremium = userIsPremium;
	}
}