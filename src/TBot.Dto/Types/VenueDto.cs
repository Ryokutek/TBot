using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a venue.
/// </summary>
public class VenueDto
{
	/// <summary>
	/// Venue location. Can't be a live location
	/// </summary>
	[JsonPropertyName("location")]
	public LocationDto Location { get; set; } = null!;

	/// <summary>
	/// Name of the venue
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Address of the venue
	/// </summary>
	[JsonPropertyName("address")]
	public string Address { get; set; } = null!;

	/// <summary>
	/// Optional. Foursquare identifier of the venue
	/// </summary>
	[JsonPropertyName("foursquare_id")]
	public string? FoursquareId { get; set; }

	/// <summary>
	/// Optional. Foursquare type of the venue. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
	/// </summary>
	[JsonPropertyName("foursquare_type")]
	public string? FoursquareType { get; set; }

	/// <summary>
	/// Optional. Google Places identifier of the venue
	/// </summary>
	[JsonPropertyName("google_place_id")]
	public string? GooglePlaceId { get; set; }

	/// <summary>
	/// Optional. Google Places type of the venue. (See supported types.)
	/// </summary>
	[JsonPropertyName("google_place_type")]
	public string? GooglePlaceType { get; set; }
}