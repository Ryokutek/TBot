using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// This object represents one button of the reply keyboard. For simple text buttons, String can be used instead of this object to specify the button text. The optional fields web_app, request_user, request_chat, request_contact, request_location, and request_poll are mutually exclusive.
/// </summary>
public class KeyboardButtonDto
{
	/// <summary>
	/// Text of the button. If none of the optional fields are used, it will be sent as a message when the button is pressed
	/// </summary>
	[JsonPropertyName("text")]
	public string Text { get; set; } = null!;

	/// <summary>
	/// Optional. If specified, pressing the button will open a list of suitable users. Tapping on any user will send their identifier to the bot in a “user_shared” service message. Available in private chats only.
	/// </summary>
	[JsonPropertyName("request_user")]
	public KeyboardButtonRequestUserDto? RequestUser { get; set; }

	/// <summary>
	/// Optional. If specified, pressing the button will open a list of suitable chats. Tapping on a chat will send its identifier to the bot in a “chat_shared” service message. Available in private chats only.
	/// </summary>
	[JsonPropertyName("request_chat")]
	public KeyboardButtonRequestChatDto? RequestChat { get; set; }

	/// <summary>
	/// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only.
	/// </summary>
	[JsonPropertyName("request_contact")]
	public bool? RequestContact { get; set; }

	/// <summary>
	/// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only.
	/// </summary>
	[JsonPropertyName("request_location")]
	public bool? RequestLocation { get; set; }

	/// <summary>
	/// Optional. If specified, the user will be asked to create a poll and send it to the bot when the button is pressed. Available in private chats only.
	/// </summary>
	[JsonPropertyName("request_poll")]
	public KeyboardButtonPollTypeDto? RequestPoll { get; set; }

	/// <summary>
	/// Optional. If specified, the described Web App will be launched when the button is pressed. The Web App will be able to send a “web_app_data” service message. Available in private chats only.
	/// </summary>
	[JsonPropertyName("web_app")]
	public WebAppInfoDto? WebApp { get; set; }
}