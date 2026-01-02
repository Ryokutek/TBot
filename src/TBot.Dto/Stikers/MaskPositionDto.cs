using System.Text.Json.Serialization;

namespace TBot.Dto.Stikers;

/// <summary>
/// This object describes the position on faces where a mask should be placed by default.
/// </summary>
public abstract class MaskPositionDto
{
	/// <summary>
	/// The part of the face relative to which the mask should be placed. One of “forehead”, “eyes”, “mouth”, or “chin”.
	/// </summary>
	[JsonPropertyName("point")]
	public string Point { get; set; } = null!;

	/// <summary>
	/// Shift by X-axis measured in widths of the mask scaled to the face size, from left to right. For example, choosing -1.0 will place mask just to the left of the default mask position.
	/// </summary>
	[JsonPropertyName("x_shift")]
	public float XShift { get; set; }

	/// <summary>
	/// Shift by Y-axis measured in heights of the mask scaled to the face size, from top to bottom. For example, 1.0 will place the mask just below the default mask position.
	/// </summary>
	[JsonPropertyName("y_shift")]
	public float YShift { get; set; }

	/// <summary>
	/// Mask scaling coefficient. For example, 2.0 means double size.
	/// </summary>
	[JsonPropertyName("scale")]
	public float Scale { get; set; }
}