using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// This object represents changes in the status of a chat member.
/// </summary>
public abstract class ChatMemberUpdatedDto
{
	/// <summary>
	/// Chat the user belongs to
	/// </summary>
	[JsonPropertyName("chat")]
	public ChatDto Chat { get; set; } = null!;

	/// <summary>
	/// Performer of the action, which resulted in the change
	/// </summary>
	[JsonPropertyName("from")]
	public UserDto From { get; set; } = null!;

	/// <summary>
	/// Date the change was done in Unix time
	/// </summary>
	[JsonPropertyName("date")]
	public int Date { get; set; }

	/// <summary>
	/// Previous information about the chat member
	/// </summary>
	[JsonPropertyName("old_chat_member")]
	public ChatMemberDto OldChatMember { get; set; } = null!;

	/// <summary>
	/// New information about the chat member
	/// </summary>
	[JsonPropertyName("new_chat_member")]
	public ChatMemberDto NewChatMember { get; set; } = null!;

	/// <summary>
	/// Optional. Chat invite link, which was used by the user to join the chat; for joining by invite link events only.
	/// </summary>
	[JsonPropertyName("invite_link")]
	public ChatInviteLinkDto? InviteLink { get; set; }

	/// <summary>
	/// Optional. True, if the user joined the chat via a chat folder invite link
	/// </summary>
	[JsonPropertyName("via_chat_folder_invite_link")]
	public bool? ViaChatFolderInviteLink { get; set; }
}