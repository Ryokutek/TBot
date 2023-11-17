namespace TBot.Core.Telegram;

public class ChatAdministratorRights
{
	public bool IsAnonymous { get; set; }
	public bool CanManageChat { get; set; }
	public bool CanDeleteMessages { get; set; }
	public bool CanManageVideoChats { get; set; }
	public bool CanRestrictMembers { get; set; }
	public bool CanPromoteMembers { get; set; }
	public bool CanChangeInfo { get; set; }
	public bool CanInviteUsers { get; set; }
	public bool? CanPostMessages { get; set; }
	public bool? CanEditMessages { get; set; }
	public bool? CanPinMessages { get; set; }
	public bool? CanPostStories { get; set; }
	public bool? CanEditStories { get; set; }
	public bool? CanDeleteStories { get; set; }
	public bool? CanManageTopics { get; set; }

	public ChatAdministratorRights(
		bool isAnonymous,
		bool canManageChat,
		bool canDeleteMessages,
		bool canManageVideoChats,
		bool canRestrictMembers,
		bool canPromoteMembers,
		bool canChangeInfo,
		bool canInviteUsers,
		bool? canPostMessages,
		bool? canEditMessages,
		bool? canPinMessages,
		bool? canPostStories,
		bool? canEditStories,
		bool? canDeleteStories,
		bool? canManageTopics)
	{
		IsAnonymous = isAnonymous;
		CanManageChat = canManageChat;
		CanDeleteMessages = canDeleteMessages;
		CanManageVideoChats = canManageVideoChats;
		CanRestrictMembers = canRestrictMembers;
		CanPromoteMembers = canPromoteMembers;
		CanChangeInfo = canChangeInfo;
		CanInviteUsers = canInviteUsers;
		CanPostMessages = canPostMessages;
		CanEditMessages = canEditMessages;
		CanPinMessages = canPinMessages;
		CanPostStories = canPostStories;
		CanEditStories = canEditStories;
		CanDeleteStories = canDeleteStories;
		CanManageTopics = canManageTopics;
	}
}