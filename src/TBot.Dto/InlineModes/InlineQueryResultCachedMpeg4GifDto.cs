using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound) stored on the Telegram servers. By default, this animated MPEG-4 file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
/// </summary>
public abstract class InlineQueryResultCachedMpeg4GifDto
{
	/// <summary>
	/// Type of the result, must be mpeg4_gif
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// A valid file identifier for the MPEG4 file
	/// </summary>
	[JsonPropertyName("mpeg4_file_id")]
	public string Mpeg4FileId { get; set; } = null!;

	/// <summary>
	/// Optional. Title for the result
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	/// <summary>
	/// Optional. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
	/// </summary>
	[JsonPropertyName("caption")]
	public string? Caption { get; set; }

	/// <summary>
	/// Optional. Mode for parsing entities in the caption. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("caption_entities")]
	public List<MessageEntityDto>? CaptionEntities { get; set; }

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. Content of the message to be sent instead of the video animation
	/// </summary>
	[JsonPropertyName("input_message_content")]
	public InputMessageContentDto? InputMessageContent { get; set; }
}