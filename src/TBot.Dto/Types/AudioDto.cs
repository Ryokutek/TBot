using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents an audio file to be treated as music by the Telegram clients.
/// </summary>
public abstract class AudioDto
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
	/// Duration of the audio in seconds as defined by sender
	/// </summary>
	[JsonPropertyName("duration")]
	public int Duration { get; set; }

	/// <summary>
	/// Optional. Performer of the audio as defined by sender or by audio tags
	/// </summary>
	[JsonPropertyName("performer")]
	public string? Performer { get; set; }

	/// <summary>
	/// Optional. Title of the audio as defined by sender or by audio tags
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }

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

	/// <summary>
	/// Optional. Thumbnail of the album cover to which the music file belongs
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public PhotoSizeDto? Thumbnail { get; set; }
}