using System.Text.Json.Serialization;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Represents an issue in an unspecified place. The error is considered resolved when new data is added.
/// </summary>
public class PassportElementErrorUnspecifiedDto
{
	/// <summary>
	/// Error source, must be unspecified
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// Type of element of the user's Telegram Passport which has the issue
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Base64-encoded element hash
	/// </summary>
	[JsonPropertyName("element_hash")]
	public string ElementHash { get; set; } = null!;

	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;
}