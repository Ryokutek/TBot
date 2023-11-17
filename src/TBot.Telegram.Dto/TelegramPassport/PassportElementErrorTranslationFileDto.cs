using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.TelegramPassport;

/// <summary>
/// Represents an issue with one of the files that constitute the translation of a document. The error is considered resolved when the file changes.
/// </summary>
public class PassportElementErrorTranslationFileDto
{
	/// <summary>
	/// Error source, must be translation_file
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// Type of element of the user's Telegram Passport which has the issue, one of “passport”, “driver_license”, “identity_card”, “internal_passport”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
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