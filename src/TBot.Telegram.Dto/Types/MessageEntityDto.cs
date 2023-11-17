using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
/// </summary>
public class MessageEntityDto
{
	/// <summary>
	/// Type of the entity. Currently, can be “mention” (@username), “hashtag” (#hashtag), “cashtag” ($USD), “bot_command” (/start@jobs_bot), “url” (https://telegram.org), “email” (do-not-reply@telegram.org), “phone_number” (+1-212-555-0123), “bold” (bold text), “italic” (italic text), “underline” (underlined text), “strikethrough” (strikethrough text), “spoiler” (spoiler message), “code” (monowidth string), “pre” (monowidth block), “text_link” (for clickable text URLs), “text_mention” (for users without usernames), “custom_emoji” (for inline custom emoji stickers)
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Offset in UTF-16 code units to the start of the entity
	/// </summary>
	[JsonPropertyName("offset")]
	public int Offset { get; set; }

	/// <summary>
	/// Length of the entity in UTF-16 code units
	/// </summary>
	[JsonPropertyName("length")]
	public int Length { get; set; }

	/// <summary>
	/// Optional. For “text_link” only, URL that will be opened after user taps on the text
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	/// <summary>
	/// Optional. For “text_mention” only, the mentioned user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto? User { get; set; }

	/// <summary>
	/// Optional. For “pre” only, the programming language of the entity text
	/// </summary>
	[JsonPropertyName("language")]
	public string? Language { get; set; }

	/// <summary>
	/// Optional. For “custom_emoji” only, unique identifier of the custom emoji. Use getCustomEmojiStickers to get full information about the sticker
	/// </summary>
	[JsonPropertyName("custom_emoji_id")]
	public string? CustomEmojiId { get; set; }
}