using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a location to which a chat is connected.
/// </summary>
public class ChatLocationDto
{
	/// <summary>
	/// The location to which the supergroup is connected. Can't be a live location.
	/// </summary>
	[JsonPropertyName("location")]
	public LocationDto Location { get; set; } = null!;

	/// <summary>
	/// Location address; 1-64 characters, as defined by the chat owner
	/// </summary>
	[JsonPropertyName("address")]
	public string Address { get; set; } = null!;
}