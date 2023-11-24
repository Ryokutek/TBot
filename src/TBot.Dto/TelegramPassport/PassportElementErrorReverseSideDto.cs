using System.Text.Json.Serialization;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Represents an issue with the reverse side of a document. The error is considered resolved when the file with reverse side of the document changes.
/// </summary>
public class PassportElementErrorReverseSideDto
{
	/// <summary>
	/// Error source, must be reverse_side
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// The section of the user's Telegram Passport which has the issue, one of “driver_license”, “identity_card”
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Base64-encoded hash of the file with the reverse side of the document
	/// </summary>
	[JsonPropertyName("file_hash")]
	public string FileHash { get; set; } = null!;

	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;
}