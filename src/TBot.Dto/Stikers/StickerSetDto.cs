using System.Text.Json.Serialization;
using TBot.Dto.Types;

namespace TBot.Dto.Stikers;

/// <summary>
/// This object represents a sticker set.
/// </summary>
public class StickerSetDto
{
	/// <summary>
	/// Sticker set name
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// Sticker set title
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Type of stickers in the set, currently one of “regular”, “mask”, “custom_emoji”
	/// </summary>
	[JsonPropertyName("sticker_type")]
	public string StickerType { get; set; } = null!;

	/// <summary>
	/// True, if the sticker set contains animated stickers
	/// </summary>
	[JsonPropertyName("is_animated")]
	public bool IsAnimated { get; set; }

	/// <summary>
	/// True, if the sticker set contains video stickers
	/// </summary>
	[JsonPropertyName("is_video")]
	public bool IsVideo { get; set; }

	/// <summary>
	/// List of all set stickers
	/// </summary>
	[JsonPropertyName("stickers")]
	public List<StickerDto> Stickers { get; set; } = null!;

	/// <summary>
	/// Optional. Sticker set thumbnail in the .WEBP, .TGS, or .WEBM format
	/// </summary>
	[JsonPropertyName("thumbnail")]
	public PhotoSizeDto? Thumbnail { get; set; }
}