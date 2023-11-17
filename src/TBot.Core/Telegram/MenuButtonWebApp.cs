namespace TBot.Core.Telegram;

public class MenuButtonWebApp
{
	public string Type { get; set; }
	public string Text { get; set; }
	public WebAppInfo WebApp { get; set; }

	public MenuButtonWebApp(string type, string text, WebAppInfo webApp)
	{
		Type = type;
		Text = text;
		WebApp = webApp;
	}
}