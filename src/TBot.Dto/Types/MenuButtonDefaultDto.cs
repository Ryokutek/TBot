using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Describes that no specific value for the menu button was set.
/// </summary>
public class MenuButtonDefaultDto
{
	/// <summary>
	/// Type of the button, must be default
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;
}