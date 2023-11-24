using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents a general file (as opposed to photos, voice messages and audio files).
/// </summary>
public class DocumentDto
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
	/// Optional. Document thumbnail as defined by sender
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public PhotoSizeDto? Thumbnail { get; set; }

	/// <summary>
	/// Optional. Original filename as defined by sender
	/// </summary>
	[JsonPropertyName("file_name")]
	public string? FileName { get; set; }

	/// <summary>
	/// Optional. MIME type of the file as defined by sender
	/// </summary>
	[JsonPropertyName("mime_type")]
	public string? MimeType { get; set; }

	/// <summary>
	/// Optional. File size in bytes. It can be bigger than 2^31 and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this value.
	/// </summary>
	[JsonPropertyName("file_size")]
	public int? FileSize { get; set; }
}