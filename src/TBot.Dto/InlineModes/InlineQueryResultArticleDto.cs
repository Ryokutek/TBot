using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a link to an article or web page.
/// </summary>
public abstract class InlineQueryResultArticleDto
{
	/// <summary>
	/// Type of the result, must be article
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 Bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Title of the result
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Content of the message to be sent
	/// </summary>
	[JsonPropertyName("input_message_content")]
	public InputMessageContentDto InputMessageContent { get; set; } = null!;

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. URL of the result
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	/// <summary>
	/// Optional. Pass True if you don't want the URL to be shown in the message
	/// </summary>
	[JsonPropertyName("hide_url")]
	public bool? HideUrl { get; set; }

	/// <summary>
	/// Optional. Short description of the result
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Optional. Url of the thumbnail for the result
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