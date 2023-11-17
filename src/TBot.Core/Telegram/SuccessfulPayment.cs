namespace TBot.Core.Telegram;

public class SuccessfulPayment
{
	public string Currency { get; set; }
	public int TotalAmount { get; set; }
	public string InvoicePayload { get; set; }
	public string? ShippingOptionId { get; set; }
	public OrderInfo? OrderInfo { get; set; }
	public string TelegramPaymentChargeId { get; set; }
	public string ProviderPaymentChargeId { get; set; }

	public SuccessfulPayment(
		string currency,
		int totalAmount,
		string invoicePayload,
		string? shippingOptionId,
		OrderInfo? orderInfo,
		string telegramPaymentChargeId,
		string providerPaymentChargeId)
	{
		Currency = currency;
		TotalAmount = totalAmount;
		InvoicePayload = invoicePayload;
		ShippingOptionId = shippingOptionId;
		OrderInfo = orderInfo;
		TelegramPaymentChargeId = telegramPaymentChargeId;
		ProviderPaymentChargeId = providerPaymentChargeId;
	}
}