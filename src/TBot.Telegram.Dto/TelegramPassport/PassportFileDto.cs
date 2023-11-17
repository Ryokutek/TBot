using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.TelegramPassport;

/// <summary>
/// This object represents a file uploaded to Telegram Passport. Currently all Telegram Passport files are in JPEG format when decrypted and don't exceed 10MB.
/// </summary>
public class PassportFileDto
{
	/// <summary>
	/// Identifier for this file, which can be used to download or reuse the file
	/// </summary>
	[JsonPropertyName("file_id")]
	public string FileId { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
	/// </summary>
	[JsonPropertyName("file_unique_id")]
	public string FileUniqueId { get; set; } = null!;

	/// <summary>
	/// File size in bytes
	/// </summary>
	[JsonPropertyName("file_size")]
	public int FileSize { get; set; }

	/// <summary>
	/// Unix time when the file was uploaded
	/// </summary>
	[JsonPropertyName("file_date")]
	public int FileDate { get; set; }
}