using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents a video message (available in Telegram apps as of v.4.0).
/// </summary>
public class VideoNoteDto
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
	/// Video width and height (diameter of the video message) as defined by sender
	/// </summary>
	[JsonPropertyName("length")]
	public int Length { get; set; }

	/// <summary>
	/// Duration of the video in seconds as defined by sender
	/// </summary>
	[JsonPropertyName("duration")]
	public int Duration { get; set; }

	/// <summary>
	/// Optional. Video thumbnail
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public PhotoSizeDto? Thumbnail { get; set; }

	/// <summary>
	/// Optional. File size in bytes
	/// </summary>
	[JsonPropertyName("file_size")]
	public int? FileSize { get; set; }
}