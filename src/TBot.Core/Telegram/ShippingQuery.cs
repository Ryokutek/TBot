namespace TBot.Core.Telegram;

public class ShippingQuery
{
	public string Id { get; set; }
	public User From { get; set; }
	public string InvoicePayload { get; set; }
	public ShippingAddress ShippingAddress { get; set; }

	public ShippingQuery(
		string id,
		User from,
		string invoicePayload,
		ShippingAddress shippingAddress)
	{
		Id = id;
		From = from;
		InvoicePayload = invoicePayload;
		ShippingAddress = shippingAddress;
	}
}