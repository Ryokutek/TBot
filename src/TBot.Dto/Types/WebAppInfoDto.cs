using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Describes a Web App.
/// </summary>
public abstract class WebAppInfoDto
{
	/// <summary>
	/// An HTTPS URL of a Web App to be opened with additional data as specified in Initializing Web Apps
	/// </summary>
	[JsonPropertyName("url")]
	public string Url { get; set; } = null!;
}