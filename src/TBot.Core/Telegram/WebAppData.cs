namespace TBot.Core.Telegram;

public class WebAppData
{
	public string Data { get; set; }
	public string ButtonText { get; set; }

	public WebAppData(string data, string buttonText)
	{
		Data = data;
		ButtonText = buttonText;
	}
}