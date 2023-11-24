using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a point on the map.
/// </summary>
public class LocationDto
{
	/// <summary>
	/// Longitude as defined by sender
	/// </summary>
	[JsonPropertyName("longitude")]
	public float Longitude { get; set; }

	/// <summary>
	/// Latitude as defined by sender
	/// </summary>
	[JsonPropertyName("latitude")]
	public float Latitude { get; set; }

	/// <summary>
	/// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
	/// </summary>
	[JsonPropertyName("horizontal_accuracy")]
	public float? HorizontalAccuracy { get; set; }

	/// <summary>
	/// Optional. Time relative to the message sending date, during which the location can be updated; in seconds. For active live locations only.
	/// </summary>
	[JsonPropertyName("live_period")]
	public int? LivePeriod { get; set; }

	/// <summary>
	/// Optional. The direction in which user is moving, in degrees; 1-360. For active live locations only.
	/// </summary>
	[JsonPropertyName("heading")]
	public int? Heading { get; set; }

	/// <summary>
	/// Optional. The maximum distance for proximity alerts about approaching another chat member, in meters. For sent live locations only.
	/// </summary>
	[JsonPropertyName("proximity_alert_radius")]
	public int? ProximityAlertRadius { get; set; }
}