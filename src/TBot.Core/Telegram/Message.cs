namespace TBot.Core.Telegram;

public class Message
{
	public int MessageId { get; set; }
	public int? MessageThreadId { get; set; }
	public User? From { get; set; }
	public Chat? SenderChat { get; set; }
	public int Date { get; set; }
	public Chat Chat { get; set; }
	public User? ForwardFrom { get; set; }
	public Chat? ForwardFromChat { get; set; }
	public int? ForwardFromMessageId { get; set; }
	public string? ForwardSignature { get; set; }
	public string? ForwardSenderName { get; set; }
	public int? ForwardDate { get; set; }
	public bool? IsTopicMessage { get; set; }
	public bool? IsAutomaticForward { get; set; }
	public Message? ReplyToMessage { get; set; }
	public User? ViaBot { get; set; }
	public int? EditDate { get; set; }
	public bool? HasProtectedContent { get; set; }
	public string? MediaGroupId { get; set; }
	public string? AuthorSignature { get; set; }
	public string? Text { get; set; }
	public List<MessageEntity>? Entities { get; set; }
	public Animation? Animation { get; set; }
	public Audio? Audio { get; set; }
	public Document? Document { get; set; }
	public List<PhotoSize>? Photo { get; set; }
	public Sticker? Sticker { get; set; }
	public Story? Story { get; set; }
	public Video? Video { get; set; }
	public VideoNote? VideoNote { get; set; }
	public Voice? Voice { get; set; }
	public string? Caption { get; set; }
	public List<MessageEntity> CaptionEntities { get; set; }
	public bool? HasMediaSpoiler { get; set; }
	public Contact? Contact { get; set; }
	public Dice? Dice { get; set; }
	public Game? Game { get; set; }
	public Poll? Poll { get; set; }
	public Venue? Venue { get; set; }
	public Location? Location { get; set; }
	public List<User> NewChatMembers { get; set; }
	public User? LeftChatMember { get; set; }
	public string? NewChatTitle { get; set; }
	public List<PhotoSize> NewChatPhoto { get; set; }
	public bool? DeleteChatPhoto { get; set; }
	public bool? GroupChatCreated { get; set; }
	public bool? SupergroupChatCreated { get; set; }
	public bool? ChannelChatCreated { get; set; }
	public MessageAutoDeleteTimerChanged? MessageAutoDeleteTimerChanged { get; set; }
	public int? MigrateToChatId { get; set; }
	public int? MigrateFromChatId { get; set; }
	public Message? PinnedMessage { get; set; }
	public Invoice? Invoice { get; set; }
	public SuccessfulPayment? SuccessfulPayment { get; set; }
	public UserShared? UserShared { get; set; }
	public ChatShared? ChatShared { get; set; }
	public string? ConnectedWebsite { get; set; }
	public WriteAccessAllowed? WriteAccessAllowed { get; set; }
	public PassportData? PassportData { get; set; }
	public ProximityAlertTriggered? ProximityAlertTriggered { get; set; }
	public ForumTopicCreated? ForumTopicCreated { get; set; }
	public ForumTopicEdited? ForumTopicEdited { get; set; }
	public ForumTopicClosed? ForumTopicClosed { get; set; }
	public ForumTopicReopened? ForumTopicReopened { get; set; }
	public GeneralForumTopicHidden? GeneralForumTopicHidden { get; set; }
	public GeneralForumTopicUnhidden? GeneralForumTopicUnhidden { get; set; }
	public VideoChatScheduled? VideoChatScheduled { get; set; }
	public VideoChatStarted? VideoChatStarted { get; set; }
	public VideoChatEnded? VideoChatEnded { get; set; }
	public VideoChatParticipantsInvited? VideoChatParticipantsInvited { get; set; }
	public WebAppData? WebAppData { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }

	public Message(
		int messageId,
		int? messageThreadId,
		User? from,
		Chat? senderChat,
		int date,
		Chat chat,
		User? forwardFrom,
		Chat? forwardFromChat,
		int? forwardFromMessageId,
		string? forwardSignature,
		string? forwardSenderName,
		int? forwardDate,
		bool? isTopicMessage,
		bool? isAutomaticForward,
		Message? replyToMessage,
		User? viaBot,
		int? editDate,
		bool? hasProtectedContent,
		string? mediaGroupId,
		string? authorSignature,
		string? text,
		List<MessageEntity>? entities,
		Animation? animation,
		Audio? audio,
		Document? document,
		List<PhotoSize>? photo,
		Sticker? sticker,
		Story? story,
		Video? video,
		VideoNote? videoNote,
		Voice? voice,
		string? caption,
		List<MessageEntity>? captionEntities,
		bool? hasMediaSpoiler,
		Contact? contact,
		Dice? dice,
		Game? game,
		Poll? poll,
		Venue? venue,
		Location? location,
		List<User>? newChatMembers,
		User? leftChatMember,
		string? newChatTitle,
		List<PhotoSize>? newChatPhoto,
		bool? deleteChatPhoto,
		bool? groupChatCreated,
		bool? supergroupChatCreated,
		bool? channelChatCreated,
		MessageAutoDeleteTimerChanged? messageAutoDeleteTimerChanged,
		int? migrateToChatId,
		int? migrateFromChatId,
		Message? pinnedMessage,
		Invoice? invoice,
		SuccessfulPayment? successfulPayment,
		UserShared? userShared,
		ChatShared? chatShared,
		string? connectedWebsite,
		WriteAccessAllowed? writeAccessAllowed,
		PassportData? passportData,
		ProximityAlertTriggered? proximityAlertTriggered,
		ForumTopicCreated? forumTopicCreated,
		ForumTopicEdited? forumTopicEdited,
		ForumTopicClosed? forumTopicClosed,
		ForumTopicReopened? forumTopicReopened,
		GeneralForumTopicHidden? generalForumTopicHidden,
		GeneralForumTopicUnhidden? generalForumTopicUnhidden,
		VideoChatScheduled? videoChatScheduled,
		VideoChatStarted? videoChatStarted,
		VideoChatEnded? videoChatEnded,
		VideoChatParticipantsInvited? videoChatParticipantsInvited,
		WebAppData? webAppData,
		InlineKeyboardMarkup? replyMarkup)
	{
		MessageId = messageId;
		MessageThreadId = messageThreadId;
		From = from;
		SenderChat = senderChat;
		Date = date;
		Chat = chat;
		ForwardFrom = forwardFrom;
		ForwardFromChat = forwardFromChat;
		ForwardFromMessageId = forwardFromMessageId;
		ForwardSignature = forwardSignature;
		ForwardSenderName = forwardSenderName;
		ForwardDate = forwardDate;
		IsTopicMessage = isTopicMessage;
		IsAutomaticForward = isAutomaticForward;
		ReplyToMessage = replyToMessage;
		ViaBot = viaBot;
		EditDate = editDate;
		HasProtectedContent = hasProtectedContent;
		MediaGroupId = mediaGroupId;
		AuthorSignature = authorSignature;
		Text = text;
		Entities = entities;
		Animation = animation;
		Audio = audio;
		Document = document;
		Photo = photo;
		Sticker = sticker;
		Story = story;
		Video = video;
		VideoNote = videoNote;
		Voice = voice;
		Caption = caption;
		CaptionEntities = captionEntities;
		HasMediaSpoiler = hasMediaSpoiler;
		Contact = contact;
		Dice = dice;
		Game = game;
		Poll = poll;
		Venue = venue;
		Location = location;
		NewChatMembers = newChatMembers;
		LeftChatMember = leftChatMember;
		NewChatTitle = newChatTitle;
		NewChatPhoto = newChatPhoto;
		DeleteChatPhoto = deleteChatPhoto;
		GroupChatCreated = groupChatCreated;
		SupergroupChatCreated = supergroupChatCreated;
		ChannelChatCreated = channelChatCreated;
		MessageAutoDeleteTimerChanged = messageAutoDeleteTimerChanged;
		MigrateToChatId = migrateToChatId;
		MigrateFromChatId = migrateFromChatId;
		PinnedMessage = pinnedMessage;
		Invoice = invoice;
		SuccessfulPayment = successfulPayment;
		UserShared = userShared;
		ChatShared = chatShared;
		ConnectedWebsite = connectedWebsite;
		WriteAccessAllowed = writeAccessAllowed;
		PassportData = passportData;
		ProximityAlertTriggered = proximityAlertTriggered;
		ForumTopicCreated = forumTopicCreated;
		ForumTopicEdited = forumTopicEdited;
		ForumTopicClosed = forumTopicClosed;
		ForumTopicReopened = forumTopicReopened;
		GeneralForumTopicHidden = generalForumTopicHidden;
		GeneralForumTopicUnhidden = generalForumTopicUnhidden;
		VideoChatScheduled = videoChatScheduled;
		VideoChatStarted = videoChatStarted;
		VideoChatEnded = videoChatEnded;
		VideoChatParticipantsInvited = videoChatParticipantsInvited;
		WebAppData = webAppData;
		ReplyMarkup = replyMarkup;
	}

	public Message()
	{
		
	}
}