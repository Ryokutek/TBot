namespace TBot.Core.Telegram;

public class WebAppInfo
{
	public string Url { get; set; }

	public WebAppInfo(string url)
	{
		Url = url;
	}
}