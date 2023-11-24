using System.Text.Json.Serialization;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents the content of a location message to be sent as the result of an inline query.
/// </summary>
public class InputLocationMessageContentDto
{
	/// <summary>
	/// Latitude of the location in degrees
	/// </summary>
	[JsonPropertyName("latitude")]
	public float Latitude { get; set; }

	/// <summary>
	/// Longitude of the location in degrees
	/// </summary>
	[JsonPropertyName("longitude")]
	public float Longitude { get; set; }

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
}