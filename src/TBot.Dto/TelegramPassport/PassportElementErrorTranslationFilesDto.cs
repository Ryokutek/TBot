using System.Text.Json.Serialization;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Represents an issue with the translated version of a document. The error is considered resolved when a file with the document translation change.
/// </summary>
public class PassportElementErrorTranslationFilesDto
{
	/// <summary>
	/// Error source, must be translation_files
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// Type of element of the user's Telegram Passport which has the issue, one of “passport”, “driver_license”, “identity_card”, “internal_passport”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// List of base64-encoded file hashes
	/// </summary>
	[JsonPropertyName("file_hashes")]
	public List<string> FileHashes { get; set; } = null!;

	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;
}