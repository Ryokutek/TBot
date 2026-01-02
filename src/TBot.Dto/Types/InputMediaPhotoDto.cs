using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Represents a photo to be sent.
/// </summary>
public abstract class InputMediaPhotoDto
{
	/// <summary>
	/// Type of the result, must be photo
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended), pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://<file_attach_name>” to upload a new one using multipart/form-data under <file_attach_name> name. More information on Sending Files »
	/// </summary>
	[JsonPropertyName("media")]
	public string Media { get; set; } = null!;

	/// <summary>
	/// Optional. Caption of the photo to be sent, 0-1024 characters after entities parsing
	/// </summary>
	[JsonPropertyName("caption")]
	public string? Caption { get; set; }

	/// <summary>
	/// Optional. Mode for parsing entities in the photo caption. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("caption_entities")]
	public List<MessageEntityDto>? CaptionEntities { get; set; }

	/// <summary>
	/// Optional. Pass True if the photo needs to be covered with a spoiler animation
	/// </summary>
	[JsonPropertyName("has_spoiler")]
	public bool? HasSpoiler { get; set; }
}