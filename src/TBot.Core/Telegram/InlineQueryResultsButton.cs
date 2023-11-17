namespace TBot.Core.Telegram;

public class InlineQueryResultsButton
{
	public string Text { get; set; }
	public WebAppInfo? WebApp { get; set; }
	public string? StartParameter { get; set; }

	public InlineQueryResultsButton(string text, WebAppInfo? webApp, string? startParameter)
	{
		Text = text;
		WebApp = webApp;
		StartParameter = startParameter;
	}
}