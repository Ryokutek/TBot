namespace TBot.Core.Telegram;

public class ShippingOption
{
	public string Id { get; set; }
	public string Title { get; set; }
	public List<LabeledPrice> Prices { get; set; }

	public ShippingOption(string id, string title, List<LabeledPrice> prices)
	{
		Id = id;
		Title = title;
		Prices = prices;
	}
}