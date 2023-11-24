using System.Text.Json.Serialization;

namespace TBot.Dto.Payments;

/// <summary>
/// This object represents one shipping option.
/// </summary>
public class ShippingOptionDto
{
	/// <summary>
	/// Shipping option identifier
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Option title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// List of price portions
	/// </summary>
	[JsonPropertyName("prices")]
	public List<LabeledPriceDto> Prices { get; set; } = null!;
}