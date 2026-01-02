using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a location on a map. By default, the location will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the location.
/// </summary>
public abstract class InlineQueryResultLocationDto
{
	/// <summary>
	/// Type of the result, must be location
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 Bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Location latitude in degrees
	/// </summary>
	[JsonPropertyName("latitude")]
	public float Latitude { get; set; }

	/// <summary>
	/// Location longitude in degrees
	/// </summary>
	[JsonPropertyName("longitude")]
	public float Longitude { get; set; }

	/// <summary>
	/// Location title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
	/// </summary>
	[JsonPropertyName("horizontal_accuracy")]
	public float? HorizontalAccuracy { get; set; }

	/// <summary>
	/// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
	/// </summary>
	[JsonPropertyName("live_period")]
	public int? LivePeriod { get; set; }

	/// <summary>
	/// Optional. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
	/// </summary>
	[JsonPropertyName("heading")]
	public int? Heading { get; set; }

	/// <summary>
	/// Optional. For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
	/// </summary>
	[JsonPropertyName("proximity_alert_radius")]
	public int? ProximityAlertRadius { get; set; }

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. Content of the message to be sent instead of the location
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