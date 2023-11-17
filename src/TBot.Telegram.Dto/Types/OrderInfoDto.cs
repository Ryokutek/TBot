using System.Text.Json.Serialization;
using TBot.Telegram.Dto.Payments;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents information about an order.
/// </summary>
public class OrderInfoDto
{
	/// <summary>
	/// Optional. User name
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Optional. User's phone number
	/// </summary>
	[JsonPropertyName("phone_number")]
	public string? PhoneNumber { get; set; }

	/// <summary>
	/// Optional. User email
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Optional. User shipping address
	/// </summary>
	[JsonPropertyName("shipping_address")]
	public ShippingAddressDto? ShippingAddress { get; set; }
}