using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the venue.
/// </summary>
public class InlineQueryResultVenueDto
{
	/// <summary>
	/// Type of the result, must be venue
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 Bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Latitude of the venue location in degrees
	/// </summary>
	[JsonPropertyName("latitude")]
	public float Latitude { get; set; }

	/// <summary>
	/// Longitude of the venue location in degrees
	/// </summary>
	[JsonPropertyName("longitude")]
	public float Longitude { get; set; }

	/// <summary>
	/// Title of the venue
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Address of the venue
	/// </summary>
	[JsonPropertyName("address")]
	public string Address { get; set; } = null!;

	/// <summary>
	/// Optional. Foursquare identifier of the venue if known
	/// </summary>
	[JsonPropertyName("foursquare_id")]
	public string? FoursquareId { get; set; }

	/// <summary>
	/// Optional. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
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

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. Content of the message to be sent instead of the venue
	/// </summary>
	[JsonPropertyName("input_message_content")]
	public InputMessageContentDto? InputMessageContent { get; set; }

	/// <summary>
	/// Optional. Url of the thumbnail for the result
	/// </summary>
	[JsonPropertyName("thumbnail_url")]
	public string? ThumbnailUrl { get; set; }

	/// <summary>
	/// Optional. Thumbnail width
	/// </summary>
	[JsonPropertyName("thumbnail_width")]
	public int? ThumbnailWidth { get; set; }

	/// <summary>
	/// Optional. Thumbnail height
	/// </summary>
	[JsonPropertyName("thumbnail_height")]
	public int? ThumbnailHeight { get; set; }
}