using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.Payments;

/// <summary>
/// This object contains information about an incoming shipping query.
/// </summary>
public class ShippingQueryDto
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
	/// Bot specified invoice payload
	/// </summary>
	[JsonPropertyName("invoice_payload")]
	public string InvoicePayload { get; set; } = null!;

	/// <summary>
	/// User specified shipping address
	/// </summary>
	[JsonPropertyName("shipping_address")]
	public ShippingAddressDto ShippingAddress { get; set; } = null!;
}