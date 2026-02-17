using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents an inline keyboard that appears right next to the message it belongs to.
/// </summary>
public class InlineKeyboardMarkupDto
{
	/// <summary>
	/// Array of button rows, each represented by an Array of InlineKeyboardButton objects
	/// </summary>
	[JsonPropertyName("inline_keyboard")]
	public List<InlineKeyboardButtonDto> InlineKeyboard { get; set; } = null!;
}