using System.Text.Json.Serialization;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Represents an issue with a document scan. The error is considered resolved when the file with the document scan changes.
/// </summary>
public class PassportElementErrorFileDto
{
	/// <summary>
	/// Error source, must be file
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// The section of the user's Telegram Passport which has the issue, one of “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Base64-encoded file hash
	/// </summary>
	[JsonPropertyName("file_hash")]
	public string FileHash { get; set; } = null!;

	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;
}