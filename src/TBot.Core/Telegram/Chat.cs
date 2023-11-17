namespace TBot.Core.Telegram;

public class Chat
{
	public long Id { get; set; }
	public string Type { get; set; }
	public string? Title { get; set; }
	public string? Username { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public bool? IsForum { get; set; }
	public ChatPhoto? Photo { get; set; }
	public List<string>? ActiveUsernames { get; set; }
	public string? EmojiStatusCustomEmojiId { get; set; }
	public int? EmojiStatusExpirationDate { get; set; }
	public string? Bio { get; set; }
	public bool? HasPrivateForwards { get; set; }
	public bool? HasRestrictedVoiceAndVideoMessages { get; set; }
	public bool? JoinToSendMessages { get; set; }
	public bool? JoinByRequest { get; set; }
	public string? Description { get; set; }
	public string? InviteLink { get; set; }
	public Message? PinnedMessage { get; set; }
	public ChatPermissions? Permissions { get; set; }
	public int? SlowModeDelay { get; set; }
	public int? MessageAutoDeleteTime { get; set; }
	public bool? HasAggressiveAntiSpamEnabled { get; set; }
	public bool? HasHiddenMembers { get; set; }
	public bool? HasProtectedContent { get; set; }
	public string? StickerSetName { get; set; }
	public bool? CanSetStickerSet { get; set; }
	public int? LinkedChatId { get; set; }
	public ChatLocation? Location { get; set; }

	public Chat(
		long id,
		string type,
		string? title,
		string? username,
		string? firstName,
		string? lastName,
		bool? isForum,
		ChatPhoto? photo,
		List<string>? activeUsernames,
		string? emojiStatusCustomEmojiId,
		int? emojiStatusExpirationDate,
		string? bio,
		bool? hasPrivateForwards,
		bool? hasRestrictedVoiceAndVideoMessages,
		bool? joinToSendMessages,
		bool? joinByRequest,
		string? description,
		string? inviteLink,
		Message? pinnedMessage,
		ChatPermissions? permissions,
		int? slowModeDelay,
		int? messageAutoDeleteTime,
		bool? hasAggressiveAntiSpamEnabled,
		bool? hasHiddenMembers,
		bool? hasProtectedContent,
		string? stickerSetName,
		bool? canSetStickerSet,
		int? linkedChatId,
		ChatLocation? location)
	{
		Id = id;
		Type = type;
		Title = title;
		Username = username;
		FirstName = firstName;
		LastName = lastName;
		IsForum = isForum;
		Photo = photo;
		ActiveUsernames = activeUsernames;
		EmojiStatusCustomEmojiId = emojiStatusCustomEmojiId;
		EmojiStatusExpirationDate = emojiStatusExpirationDate;
		Bio = bio;
		HasPrivateForwards = hasPrivateForwards;
		HasRestrictedVoiceAndVideoMessages = hasRestrictedVoiceAndVideoMessages;
		JoinToSendMessages = joinToSendMessages;
		JoinByRequest = joinByRequest;
		Description = description;
		InviteLink = inviteLink;
		PinnedMessage = pinnedMessage;
		Permissions = permissions;
		SlowModeDelay = slowModeDelay;
		MessageAutoDeleteTime = messageAutoDeleteTime;
		HasAggressiveAntiSpamEnabled = hasAggressiveAntiSpamEnabled;
		HasHiddenMembers = hasHiddenMembers;
		HasProtectedContent = hasProtectedContent;
		StickerSetName = stickerSetName;
		CanSetStickerSet = canSetStickerSet;
		LinkedChatId = linkedChatId;
		Location = location;
	}
}