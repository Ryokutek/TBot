using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents a contact with a phone number. By default, this contact will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the contact.
/// </summary>
public class InlineQueryResultContactDto
{
	/// <summary>
	/// Type of the result, must be contact
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Unique identifier for this result, 1-64 Bytes
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; } = null!;

	/// <summary>
	/// Contact's phone number
	/// </summary>
	[JsonPropertyName("phone_number")]
	public string PhoneNumber { get; set; } = null!;

	/// <summary>
	/// Contact's first name
	/// </summary>
	[JsonPropertyName("first_name")]
	public string FirstName { get; set; } = null!;

	/// <summary>
	/// Optional. Contact's last name
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes
	/// </summary>
	[JsonPropertyName("vcard")]
	public string? Vcard { get; set; }

	/// <summary>
	/// Optional. Inline keyboard attached to the message
	/// </summary>
	[JsonPropertyName("reply_markup")]
	public InlineKeyboardMarkupDto? ReplyMarkup { get; set; }

	/// <summary>
	/// Optional. Content of the message to be sent instead of the contact
	/// </summary>
	[JsonPropertyName("input_message_content")]
	public InputMessageContentDto? InputMessageContent { get; set; }

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