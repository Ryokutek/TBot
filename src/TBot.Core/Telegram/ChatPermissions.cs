namespace TBot.Core.Telegram;

public class ChatPermissions
{
	public bool? CanSendMessages { get; set; }
	public bool? CanSendAudios { get; set; }
	public bool? CanSendDocuments { get; set; }
	public bool? CanSendPhotos { get; set; }
	public bool? CanSendVideos { get; set; }
	public bool? CanSendVideoNotes { get; set; }
	public bool? CanSendVoiceNotes { get; set; }
	public bool? CanSendPolls { get; set; }
	public bool? CanSendOtherMessages { get; set; }
	public bool? CanAddWebPagePreviews { get; set; }
	public bool? CanChangeInfo { get; set; }
	public bool? CanInviteUsers { get; set; }
	public bool? CanPinMessages { get; set; }
	public bool? CanManageTopics { get; set; }

	public ChatPermissions(
		bool? canSendMessages,
		bool? canSendAudios,
		bool? canSendDocuments,
		bool? canSendPhotos,
		bool? canSendVideos,
		bool? canSendVideoNotes,
		bool? canSendVoiceNotes,
		bool? canSendPolls,
		bool? canSendOtherMessages,
		bool? canAddWebPagePreviews,
		bool? canChangeInfo,
		bool? canInviteUsers,
		bool? canPinMessages,
		bool? canManageTopics)
	{
		CanSendMessages = canSendMessages;
		CanSendAudios = canSendAudios;
		CanSendDocuments = canSendDocuments;
		CanSendPhotos = canSendPhotos;
		CanSendVideos = canSendVideos;
		CanSendVideoNotes = canSendVideoNotes;
		CanSendVoiceNotes = canSendVoiceNotes;
		CanSendPolls = canSendPolls;
		CanSendOtherMessages = canSendOtherMessages;
		CanAddWebPagePreviews = canAddWebPagePreviews;
		CanChangeInfo = canChangeInfo;
		CanInviteUsers = canInviteUsers;
		CanPinMessages = canPinMessages;
		CanManageTopics = canManageTopics;
	}
}