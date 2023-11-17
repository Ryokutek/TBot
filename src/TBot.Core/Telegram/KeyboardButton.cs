namespace TBot.Core.Telegram;

public class KeyboardButton
{
	public string Text { get; set; }
	public KeyboardButtonRequestUser? RequestUser { get; set; }
	public KeyboardButtonRequestChat? RequestChat { get; set; }
	public bool? RequestContact { get; set; }
	public bool? RequestLocation { get; set; }
	public KeyboardButtonPollType? RequestPoll { get; set; }
	public WebAppInfo? WebApp { get; set; }

	public KeyboardButton(
		string text,
		KeyboardButtonRequestUser? requestUser,
		KeyboardButtonRequestChat? requestChat,
		bool? requestContact,
		bool? requestLocation,
		KeyboardButtonPollType? requestPoll,
		WebAppInfo? webApp)
	{
		Text = text;
		RequestUser = requestUser;
		RequestChat = requestChat;
		RequestContact = requestContact;
		RequestLocation = requestLocation;
		RequestPoll = requestPoll;
		WebApp = webApp;
	}
}