using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents a chat photo.
/// </summary>
public class ChatPhotoDto
{
	/// <summary>
	/// File identifier of small (160x160) chat photo. This file_id can be used only for photo download and only for as long as the photo is not changed.
	/// </summary>
	[JsonPropertyName("small_file_id")]
	public string SmallFileId { get; set; } = null!;

	/// <summary>
	/// Unique file identifier of small (160x160) chat photo, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
	/// </summary>
	[JsonPropertyName("small_file_unique_id")]
	public string SmallFileUniqueId { get; set; } = null!;

	/// <summary>
	/// File identifier of big (640x640) chat photo. This file_id can be used only for photo download and only for as long as the photo is not changed.
	/// </summary>
	[JsonPropertyName("big_file_id")]
	public string BigFileId { get; set; } = null!;

	/// <summary>
	/// Unique file identifier of big (640x640) chat photo, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
	/// </summary>
	[JsonPropertyName("big_file_unique_id")]
	public string BigFileUniqueId { get; set; } = null!;
}