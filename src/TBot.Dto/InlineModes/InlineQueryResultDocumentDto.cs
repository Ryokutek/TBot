using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a link to a file. By default, this file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the file. Currently, only .PDF and .ZIP files can be sent using this method.
/// </summary>
public abstract class InlineQueryResultDocumentDto
{
	/// <summary>
	/// Type of the result, must be document
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Title for the result
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Optional. Caption of the document to be sent, 0-1024 characters after entities parsing
	/// </summary>
	[JsonPropertyName("caption")]
	public string? Caption { get; set; }

	/// <summary>
	/// Optional. Mode for parsing entities in the document caption. See formatting options for more details.
	/// </summary>
	[JsonPropertyName("parse_mode")]
	public string? ParseMode { get; set; }

	/// <summary>
	/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
	/// </summary>
	[JsonPropertyName("caption_entities")]
	public List<MessageEntityDto>? CaptionEntities { get; set; }

	/// <summary>
	/// A valid URL for the file
	/// </summary>
	[JsonPropertyName("document_url")]
	public string DocumentUrl { get; set; } = null!;

	/// <summary>
	/// MIME type of the content of the file, either “application/pdf” or “application/zip”
	/// </summary>
	[JsonPropertyName("mime_type")]
	public string MimeType { get; set; } = null!;

	/// <summary>
	/// Optional. Short description of the result
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. Content of the message to be sent instead of the file
	/// </summary>
	[JsonPropertyName("input_message_content")]
	public InputMessageContentDto? InputMessageContent { get; set; }

	/// <summary>
	/// Optional. URL of the thumbnail (JPEG only) for the file
	/// </summary>
	[JsonPropertyName("thumbnail_url")]
	public string? ThumbnailUrl { get; set; }

	/// <summary>
	/// Optional. Thumbnail width
	/// </summary>
	[JsonPropertyName("thumbnail_width")]
	public int? ThumbnailWidth { get; set; }

	/// <summary>
	/// Optional. Thumbnail height
	/// </summary>
	[JsonPropertyName("thumbnail_height")]
	public int? ThumbnailHeight { get; set; }
}