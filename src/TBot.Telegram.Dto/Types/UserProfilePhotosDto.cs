using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represent a user's profile pictures.
/// </summary>
public class UserProfilePhotosDto
{
	/// <summary>
	/// Total number of profile pictures the target user has
	/// </summary>
	[JsonPropertyName("total_count")]
	public int TotalCount { get; set; }

	/// <summary>
	/// Requested profile pictures (in up to 4 sizes each)
	/// </summary>
	[JsonPropertyName("photos")]
	public List<PhotoSizeDto> Photos { get; set; } = null!;
}