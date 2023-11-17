using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Payments;

/// <summary>
/// This object represents a shipping address.
/// </summary>
public class ShippingAddressDto
{
	/// <summary>
	/// Two-letter ISO 3166-1 alpha-2 country code
	/// </summary>
	[JsonPropertyName("country_code")]
	public string CountryCode { get; set; } = null!;

	/// <summary>
	/// State, if applicable
	/// </summary>
	[JsonPropertyName("state")]
	public string State { get; set; } = null!;

	/// <summary>
	/// City
	/// </summary>
	[JsonPropertyName("city")]
	public string City { get; set; } = null!;

	/// <summary>
	/// First line for the address
	/// </summary>
	[JsonPropertyName("street_line1")]
	public string StreetLine1 { get; set; } = null!;

	/// <summary>
	/// Second line for the address
	/// </summary>
	[JsonPropertyName("street_line2")]
	public string StreetLine2 { get; set; } = null!;

	/// <summary>
	/// Address post code
	/// </summary>
	[JsonPropertyName("post_code")]
	public string PostCode { get; set; } = null!;
}