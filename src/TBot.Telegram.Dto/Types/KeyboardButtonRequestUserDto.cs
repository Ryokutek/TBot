using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object defines the criteria used to request a suitable user. The identifier of the selected user will be shared with the bot when the corresponding button is pressed. More about requesting users »
/// </summary>
public class KeyboardButtonRequestUserDto
{
	/// <summary>
	/// Signed 32-bit identifier of the request, which will be received back in the UserShared object. Must be unique within the message
	/// </summary>
	[JsonPropertyName("request_id")]
	public int RequestId { get; set; }

	/// <summary>
	/// Optional. Pass True to request a bot, pass False to request a regular user. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("user_is_bot")]
	public bool? UserIsBot { get; set; }

	/// <summary>
	/// Optional. Pass True to request a premium user, pass False to request a non-premium user. If not specified, no additional restrictions are applied.
	/// </summary>
	[JsonPropertyName("user_is_premium")]
	public bool? UserIsPremium { get; set; }
}