using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents an audio file to be treated as music to be sent.
/// </summary>
public class InputMediaAudioDto
{
	/// <summary>
	/// Type of the result, must be audio
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
	/// Optional. Caption of the audio to be sent, 0-1024 characters after entities parsing
	/// </summary>
	[JsonPropertyName("caption")]
	public string? Caption { get; set; }

	/// <summary>
	/// Optional. Mode for parsing entities in the audio caption. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("caption_entities")]
	public List<MessageEntityDto>? CaptionEntities { get; set; }

	/// <summary>
	/// Optional. Duration of the audio in seconds
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// Optional. Performer of the audio
	/// </summary>
	[JsonPropertyName("performer")]
	public string? Performer { get; set; }

	/// <summary>
	/// Optional. Title of the audio
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }
}