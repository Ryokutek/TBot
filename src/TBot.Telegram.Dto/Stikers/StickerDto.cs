using System.Text.Json.Serialization;
using TBot.Telegram.Dto.Types;

namespace TBot.Telegram.Dto.Stikers;

/// <summary>
/// This object represents a sticker.
/// </summary>
public class StickerDto
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
	/// Type of the sticker, currently one of “regular”, “mask”, “custom_emoji”. The type of the sticker is independent from its format, which is determined by the fields is_animated and is_video.
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Sticker width
	/// </summary>
	[JsonPropertyName("width")]
	public int Width { get; set; }

	/// <summary>
	/// Sticker height
	/// </summary>
	[JsonPropertyName("height")]
	public int Height { get; set; }

	/// <summary>
	/// True, if the sticker is animated
	/// </summary>
	[JsonPropertyName("is_animated")]
	public bool IsAnimated { get; set; }

	/// <summary>
	/// True, if the sticker is a video sticker
	/// </summary>
	[JsonPropertyName("is_video")]
	public bool IsVideo { get; set; }

	/// <summary>
	/// Optional. Sticker thumbnail in the .WEBP or .JPG format
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public PhotoSizeDto? Thumbnail { get; set; }

	/// <summary>
	/// Optional. Emoji associated with the sticker
	/// </summary>
	[JsonPropertyName("emoji")]
	public string? Emoji { get; set; }

	/// <summary>
	/// Optional. Name of the sticker set to which the sticker belongs
	/// </summary>
	[JsonPropertyName("set_name")]
	public string? SetName { get; set; }

	/// <summary>
	/// Optional. For premium regular stickers, premium animation for the sticker
	/// </summary>
	[JsonPropertyName("premium_animation")]
	public FileDto? PremiumAnimation { get; set; }

	/// <summary>
	/// Optional. For mask stickers, the position where the mask should be placed
	/// </summary>
	[JsonPropertyName("mask_position")]
	public MaskPositionDto? MaskPosition { get; set; }

	/// <summary>
	/// Optional. For custom emoji stickers, unique identifier of the custom emoji
	/// </summary>
	[JsonPropertyName("custom_emoji_id")]
	public string? CustomEmojiId { get; set; }

	/// <summary>
	/// Optional. True, if the sticker must be repainted to a text color in messages, the color of the Telegram Premium badge in emoji status, white color on chat photos, or another appropriate color in other places
	/// </summary>
	[JsonPropertyName("needs_repainting")]
	public bool? NeedsRepainting { get; set; }

	/// <summary>
	/// Optional. File size in bytes
	/// </summary>
	[JsonPropertyName("file_size")]
	public int? FileSize { get; set; }
}