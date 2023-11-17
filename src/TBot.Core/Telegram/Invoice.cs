namespace TBot.Core.Telegram;

public class Invoice
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string StartParameter { get; set; }
	public string Currency { get; set; }
	public int TotalAmount { get; set; }

	public Invoice(
		string title,
		string description,
		string startParameter,
		string currency,
		int totalAmount)
	{
		Title = title;
		Description = description;
		StartParameter = startParameter;
		Currency = currency;
		TotalAmount = totalAmount;
	}
}