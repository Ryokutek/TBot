namespace TBot.Core.Telegram;

public class PreCheckoutQuery
{
	public string Id { get; set; }
	public User From { get; set; }
	public string Currency { get; set; }
	public int TotalAmount { get; set; }
	public string InvoicePayload { get; set; }
	public string? ShippingOptionId { get; set; }
	public OrderInfo? OrderInfo { get; set; }

	public PreCheckoutQuery(
		string id,
		User from,
		string currency,
		int totalAmount,
		string invoicePayload,
		string? shippingOptionId,
		OrderInfo? orderInfo)
	{
		Id = id;
		From = from;
		Currency = currency;
		TotalAmount = totalAmount;
		InvoicePayload = invoicePayload;
		ShippingOptionId = shippingOptionId;
		OrderInfo = orderInfo;
	}
}