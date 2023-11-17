using System.Text.Json.Serialization;

namespace TBot.Telegram.Dto.Types;

/// <summary>
/// Represents a chat member that is under certain restrictions in the chat. Supergroups only.
/// </summary>
public class ChatMemberRestrictedDto
{
	/// <summary>
	/// The member's status in the chat, always “restricted”
	/// </summary>
	[JsonPropertyName("status")]
	public string Status { get; set; } = null!;

	/// <summary>
	/// Information about the user
	/// </summary>
	[JsonPropertyName("user")]
	public UserDto User { get; set; } = null!;

	/// <summary>
	/// True, if the user is a member of the chat at the moment of the request
	/// </summary>
	[JsonPropertyName("is_member")]
	public bool IsMember { get; set; }

	/// <summary>
	/// True, if the user is allowed to send text messages, contacts, invoices, locations and venues
	/// </summary>
	[JsonPropertyName("can_send_messages")]
	public bool CanSendMessages { get; set; }

	/// <summary>
	/// True, if the user is allowed to send audios
	/// </summary>
	[JsonPropertyName("can_send_audios")]
	public bool CanSendAudios { get; set; }

	/// <summary>
	/// True, if the user is allowed to send documents
	/// </summary>
	[JsonPropertyName("can_send_documents")]
	public bool CanSendDocuments { get; set; }

	/// <summary>
	/// True, if the user is allowed to send photos
	/// </summary>
	[JsonPropertyName("can_send_photos")]
	public bool CanSendPhotos { get; set; }

	/// <summary>
	/// True, if the user is allowed to send videos
	/// </summary>
	[JsonPropertyName("can_send_videos")]
	public bool CanSendVideos { get; set; }

	/// <summary>
	/// True, if the user is allowed to send video notes
	/// </summary>
	[JsonPropertyName("can_send_video_notes")]
	public bool CanSendVideoNotes { get; set; }

	/// <summary>
	/// True, if the user is allowed to send voice notes
	/// </summary>
	[JsonPropertyName("can_send_voice_notes")]
	public bool CanSendVoiceNotes { get; set; }

	/// <summary>
	/// True, if the user is allowed to send polls
	/// </summary>
	[JsonPropertyName("can_send_polls")]
	public bool CanSendPolls { get; set; }

	/// <summary>
	/// True, if the user is allowed to send animations, games, stickers and use inline bots
	/// </summary>
	[JsonPropertyName("can_send_other_messages")]
	public bool CanSendOtherMessages { get; set; }

	/// <summary>
	/// True, if the user is allowed to add web page previews to their messages
	/// </summary>
	[JsonPropertyName("can_add_web_page_previews")]
	public bool CanAddWebPagePreviews { get; set; }

	/// <summary>
	/// True, if the user is allowed to change the chat title, photo and other settings
	/// </summary>
	[JsonPropertyName("can_change_info")]
	public bool CanChangeInfo { get; set; }

	/// <summary>
	/// True, if the user is allowed to invite new users to the chat
	/// </summary>
	[JsonPropertyName("can_invite_users")]
	public bool CanInviteUsers { get; set; }

	/// <summary>
	/// True, if the user is allowed to pin messages
	/// </summary>
	[JsonPropertyName("can_pin_messages")]
	public bool CanPinMessages { get; set; }

	/// <summary>
	/// True, if the user is allowed to create forum topics
	/// </summary>
	[JsonPropertyName("can_manage_topics")]
	public bool CanManageTopics { get; set; }

	/// <summary>
	/// Date when restrictions will be lifted for this user; unix time. If 0, then the user is restricted forever
	/// </summary>
	[JsonPropertyName("until_date")]
	public int UntilDate { get; set; }
}