using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a video to be sent.
/// </summary>
public abstract class InputMediaVideoDto
{
	/// <summary>
	/// Type of the result, must be video
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended), pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://<file_attach_name>” to upload a new one using multipart/form-data under <file_attach_name> name. More information on Sending Files »
	/// </summary>
	[JsonPropertyName("media")]
	public string Media { get; set; } = null!;

	/// <summary>
	/// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data. Thumbnails can't be reused and can be only uploaded as a new file, so you can pass “attach://<file_attach_name>” if the thumbnail was uploaded using multipart/form-data under <file_attach_name>. More information on Sending Files »
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public InputFile? Thumbnail { get; set; }

	/// <summary>
	/// Optional. Caption of the video to be sent, 0-1024 characters after entities parsing
	/// </summary>
	[JsonPropertyName("caption")]
	public string? Caption { get; set; }

	/// <summary>
	/// Optional. Mode for parsing entities in the video caption. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("caption_entities")]
	public List<MessageEntityDto>? CaptionEntities { get; set; }

	/// <summary>
	/// Optional. Video width
	/// </summary>
	[JsonPropertyName("width")]
	public int? Width { get; set; }

	/// <summary>
	/// Optional. Video height
	/// </summary>
	[JsonPropertyName("height")]
	public int? Height { get; set; }

	/// <summary>
	/// Optional. Video duration in seconds
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// Optional. Pass True if the uploaded video is suitable for streaming
	/// </summary>
	[JsonPropertyName("supports_streaming")]
	public bool? SupportsStreaming { get; set; }

	/// <summary>
	/// Optional. Pass True if the video needs to be covered with a spoiler animation
	/// </summary>
	[JsonPropertyName("has_spoiler")]
	public bool? HasSpoiler { get; set; }
}