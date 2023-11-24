using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.Payments;

/// <summary>
/// This object contains information about an incoming pre-checkout query.
/// </summary>
public class PreCheckoutQueryDto
{
	/// <summary>
	/// Unique query identifier
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// User who sent the query
	/// </summary>
	[JsonPropertyName("from")]
	public UserDto From { get; set; } = null!;

	/// <summary>
	/// Three-letter ISO 4217 currency code
	/// </summary>
	[JsonPropertyName("currency")]
	public string Currency { get; set; } = null!;

	/// <summary>
	/// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
	/// </summary>
	[JsonPropertyName("total_amount")]
	public int TotalAmount { get; set; }

	/// <summary>
	/// Bot specified invoice payload
	/// </summary>
	[JsonPropertyName("invoice_payload")]
	public string InvoicePayload { get; set; } = null!;

	/// <summary>
	/// Optional. Identifier of the shipping option chosen by the user
	/// </summary>
	[JsonPropertyName("shipping_option_id")]
	public string? ShippingOptionId { get; set; }

	/// <summary>
	/// Optional. Order information provided by the user
	/// </summary>
	[JsonPropertyName("order_info")]
	public OrderInfoDto? OrderInfo { get; set; }
}