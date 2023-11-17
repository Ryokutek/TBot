namespace TBot.Core.Telegram;

public class LabeledPrice
{
	public string Label { get; set; }
	public int Amount { get; set; }

	public LabeledPrice(string label, int amount)
	{
		Label = label;
		Amount = amount;
	}
}