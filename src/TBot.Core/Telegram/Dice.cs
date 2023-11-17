namespace TBot.Core.Telegram;

public class Dice
{
	public string Emoji { get; set; }
	public int Value { get; set; }

	public Dice(string emoji, int value)
	{
		Emoji = emoji;
		Value = value;
	}
}