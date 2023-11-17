using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.TelegramPassport;

/// <summary>
/// Represents an issue with a list of scans. The error is considered resolved when the list of files containing the scans changes.
/// </summary>
public class PassportElementErrorFilesDto
{
	/// <summary>
	/// Error source, must be files
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// The section of the user's Telegram Passport which has the issue, one of “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”
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