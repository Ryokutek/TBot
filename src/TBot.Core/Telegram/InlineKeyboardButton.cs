namespace TBot.Core.Telegram;

public class InlineKeyboardButton
{
	public string Text { get; set; }
	public string? Url { get; set; }
	public string? CallbackData { get; set; }
	public WebAppInfo? WebApp { get; set; }
	public LoginUrl? LoginUrl { get; set; }
	public string? SwitchInlineQuery { get; set; }
	public string? SwitchInlineQueryCurrentChat { get; set; }
	public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; set; }
	public CallbackGame? CallbackGame { get; set; }
	public bool? Pay { get; set; }

	public InlineKeyboardButton(
		string text,
		string? url,
		string? callbackData,
		WebAppInfo? webApp,
		LoginUrl? loginUrl,
		string? switchInlineQuery,
		string? switchInlineQueryCurrentChat,
		SwitchInlineQueryChosenChat? switchInlineQueryChosenChat,
		CallbackGame? callbackGame,
		bool? pay)
	{
		Text = text;
		Url = url;
		CallbackData = callbackData;
		WebApp = webApp;
		LoginUrl = loginUrl;
		SwitchInlineQuery = switchInlineQuery;
		SwitchInlineQueryCurrentChat = switchInlineQueryCurrentChat;
		SwitchInlineQueryChosenChat = switchInlineQueryChosenChat;
		CallbackGame = callbackGame;
		Pay = pay;
	}
}