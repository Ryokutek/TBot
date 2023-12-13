using TBot.Core.Telegram;
using TBot.Dto.Games;
using TBot.Dto.InlineModes;
using TBot.Dto.Payments;
using TBot.Dto.Stikers;
using TBot.Dto.TelegramPassport;
using TBot.Dto.Types;
using TBot.Dto.Updates;
using ChatIdentifier = TBot.Dto.Types.ChatIdentifier;
using ResponseParametersDto = TBot.Dto.Responses.ResponseParametersDto;

namespace TBot.Client.Telegram;

public static class Converter
{
	public static Update ToDomain(this UpdateDto dto)
	{
		return new Update(
			dto.UpdateId,
			dto.Message?.ToDomain(),
			dto.EditedMessage?.ToDomain(),
			dto.ChannelPost?.ToDomain(),
			dto.EditedChannelPost?.ToDomain(),
			dto.InlineQuery?.ToDomain(),
			dto.ChosenInlineResult?.ToDomain(),
			dto.CallbackQuery?.ToDomain(),
			dto.ShippingQuery?.ToDomain(),
			dto.PreCheckoutQuery?.ToDomain(),
			dto.Poll?.ToDomain(),
			dto.PollAnswer?.ToDomain(),
			dto.MyChatMember?.ToDomain(),
			dto.ChatMember?.ToDomain(),
			dto.ChatJoinRequest?.ToDomain());
	}
	
	public static User ToDomain(this UserDto dto)
	{
		return new User(
			dto.Id,
			dto.IsBot,
			dto.FirstName,
			dto.LastName,
			dto.Username,
			dto.LanguageCode,
			dto.IsPremium,
			dto.AddedToAttachmentMenu,
			dto.CanJoinGroups,
			dto.CanReadAllGroupMessages,
			dto.SupportsInlineQueries
		);
	}

	public static Chat ToDomain(this ChatDto dto)
	{
		return new Chat(
			dto.Id,
			dto.Type,
			dto.Title,
			dto.Username,
			dto.FirstName,
			dto.LastName,
			dto.IsForum,
			dto.Photo?.ToDomain(),
			dto.ActiveUsernames,
			dto.EmojiStatusCustomEmojiId,
			0, //TODO: dto.EmojiStatusExpirationDate,
			dto.Bio,
			dto.HasPrivateForwards,
			dto.HasRestrictedVoiceAndVideoMessages,
			dto.JoinToSendMessages,
			dto.JoinByRequest,
			dto.Description,
			dto.InviteLink,
			dto.PinnedMessage?.ToDomain(),
			dto.Permissions?.ToDomain(),
			dto.SlowModeDelay,
			dto.MessageAutoDeleteTime,
			dto.HasAggressiveAntiSpamEnabled,
			dto.HasHiddenMembers,
			dto.HasProtectedContent,
			dto.StickerSetName,
			dto.CanSetStickerSet,
			dto.LinkedChatId,
			dto.Location?.ToDomain()
		);
	}

	public static Message ToDomain(this MessageDto dto)
	{
		return new Message(
			dto.MessageId,
			dto.MessageThreadId,
			dto.From?.ToDomain(),
			dto.SenderChat?.ToDomain(),
			dto.Date,
			dto.Chat.ToDomain(),
			dto.ForwardFrom?.ToDomain(),
			dto.ForwardFromChat?.ToDomain(),
			dto.ForwardFromMessageId,
			dto.ForwardSignature,
			dto.ForwardSenderName,
			dto.ForwardDate,
			dto.IsTopicMessage,
			dto.IsAutomaticForward,
			dto.ReplyToMessage?.ToDomain(),
			dto.ViaBot?.ToDomain(),
			dto.EditDate,
			dto.HasProtectedContent,
			dto.MediaGroupId,
			dto.AuthorSignature,
			dto.Text,
			dto.Entities?.Select(ToDomain).ToList(),
			dto.Animation?.ToDomain(),
			dto.Audio?.ToDomain(),
			dto.Document?.ToDomain(),
			dto.Photo?.Select(ToDomain).ToList(),
			dto.Sticker?.ToDomain(),
			new Story(), //TODO: dto.Story,
			dto.Video?.ToDomain(),
			dto.VideoNote?.ToDomain(),
			dto.Voice?.ToDomain(),
			dto.Caption,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.HasMediaSpoiler,
			dto.Contact?.ToDomain(),
			dto.Dice?.ToDomain(),
			dto.Game?.ToDomain(),
			dto.Poll?.ToDomain(),
			dto.Venue?.ToDomain(),
			dto.Location?.ToDomain(),
			dto.NewChatMembers?.Select(ToDomain).ToList(),
			dto.LeftChatMember?.ToDomain(),
			dto.NewChatTitle,
			dto.NewChatPhoto?.Select(ToDomain).ToList(),
			dto.DeleteChatPhoto,
			dto.GroupChatCreated,
			dto.SupergroupChatCreated,
			dto.ChannelChatCreated,
			dto.MessageAutoDeleteTimerChanged?.ToDomain(),
			dto.MigrateToChatId,
			dto.MigrateFromChatId,
			dto.PinnedMessage?.ToDomain(),
			dto.Invoice?.ToDomain(),
			dto.SuccessfulPayment?.ToDomain(),
			new UserShared(), //TODO: dto.UserShared,
			dto.ChatShared?.ToDomain(),
			dto.ConnectedWebsite,
			dto.WriteAccessAllowed?.ToDomain(),
			dto.PassportData?.ToDomain(),
			dto.ProximityAlertTriggered?.ToDomain(),
			dto.ForumTopicCreated?.ToDomain(),
			new ForumTopicEdited(), //TODO: dto.ForumTopicEdited,
			new ForumTopicClosed(), //TODO: dto.ForumTopicClosed,
			new ForumTopicReopened(), //TODO: dto.ForumTopicReopened,
			new GeneralForumTopicHidden(), //TODO: dto.GeneralForumTopicHidden,
			new GeneralForumTopicUnhidden(), //TODO: dto.GeneralForumTopicUnhidden,
			dto.VideoChatScheduled?.ToDomain(),
			new VideoChatStarted(),//TODO: dto.VideoChatStarted,
			new VideoChatEnded(), //TODO: dto.VideoChatEnded,
			dto.VideoChatParticipantsInvited?.ToDomain(),
			dto.WebAppData?.ToDomain(),
			dto.ReplyMarkup?.ToDomain()
		);
	}

	private static Video ToDomain(this VideoDto dto)
	{
		return new Video(
			dto.FileId,
			dto.FileUniqueId,
			dto.Width,
			dto.Height,
			dto.Duration,
			dto.Thumbnail?.ToDomain(),
			dto.FileName,
			dto.MimeType,
			dto.FileSize);
	}
	
	public static MessageId ToDomain(this MessageIdDto dto)
	{
		return new MessageId(
			dto.MessageId
		);
	}

	public static MessageEntity ToDomain(this MessageEntityDto dto)
	{
		return new MessageEntity(
			dto.Type,
			dto.Offset,
			dto.Length,
			dto.Url,
			dto.User?.ToDomain(),
			dto.Language,
			dto.CustomEmojiId
		);
	}

	public static PhotoSize ToDomain(this PhotoSizeDto dto)
	{
		return new PhotoSize(
			dto.FileId,
			dto.FileUniqueId,
			dto.Width,
			dto.Height,
			dto.FileSize
		);
	}

	public static Animation ToDomain(this AnimationDto dto)
	{
		return new Animation(
			dto.FileId,
			dto.FileUniqueId,
			dto.Width,
			dto.Height,
			dto.Duration,
			dto.Thumbnail?.ToDomain(),
			dto.FileName,
			dto.MimeType,
			dto.FileSize
		);
	}

	public static Audio ToDomain(this AudioDto dto)
	{
		return new Audio(
			dto.FileId,
			dto.FileUniqueId,
			dto.Duration,
			dto.Performer,
			dto.Title,
			dto.FileName,
			dto.MimeType,
			dto.FileSize,
			dto.Thumbnail?.ToDomain()
		);
	}

	public static Document ToDomain(this DocumentDto dto)
	{
		return new Document(
			dto.FileId,
			dto.FileUniqueId,
			dto.Thumbnail?.ToDomain(),
			dto.FileName,
			dto.MimeType,
			dto.FileSize
		);
	}

	public static VideoNote ToDomain(this VideoNoteDto dto)
	{
		return new VideoNote(
			dto.FileId,
			dto.FileUniqueId,
			dto.Length,
			dto.Duration,
			dto.Thumbnail?.ToDomain(),
			dto.FileSize
		);
	}

	public static Voice ToDomain(this VoiceDto dto)
	{
		return new Voice(
			dto.FileId,
			dto.FileUniqueId,
			dto.Duration,
			dto.MimeType,
			dto.FileSize
		);
	}

	public static Contact ToDomain(this ContactDto dto)
	{
		return new Contact(
			dto.PhoneNumber,
			dto.FirstName,
			dto.LastName,
			dto.UserId,
			dto.Vcard
		);
	}

	public static Dice ToDomain(this DiceDto dto)
	{
		return new Dice(
			dto.Emoji,
			dto.Value
		);
	}

	public static PollOption ToDomain(this PollOptionDto dto)
	{
		return new PollOption(
			dto.Text,
			dto.VoterCount
		);
	}

	public static PollAnswer ToDomain(this PollAnswerDto dto)
	{
		return new PollAnswer(
			dto.PollId,
			default, //dto.VoterChat,
			dto.User.ToDomain(),
			dto.OptionIds
		);
	}

	public static Poll ToDomain(this PollDto dto)
	{
		return new Poll(
			dto.Id,
			dto.Question,
			dto.Options.Select(ToDomain).ToList(),
			dto.TotalVoterCount,
			dto.IsClosed,
			dto.IsAnonymous,
			dto.Type,
			dto.AllowsMultipleAnswers,
			dto.CorrectOptionId,
			dto.Explanation,
			dto.ExplanationEntities?.Select(ToDomain).ToList(),
			dto.OpenPeriod,
			dto.CloseDate
		);
	}

	public static Location ToDomain(this LocationDto dto)
	{
		return new Location(
			dto.Longitude,
			dto.Latitude,
			dto.HorizontalAccuracy,
			dto.LivePeriod,
			dto.Heading,
			dto.ProximityAlertRadius
		);
	}

	public static Venue ToDomain(this VenueDto dto)
	{
		return new Venue(
			dto.Location.ToDomain(),
			dto.Title,
			dto.Address,
			dto.FoursquareId,
			dto.FoursquareType,
			dto.GooglePlaceId,
			dto.GooglePlaceType
		);
	}

	public static WebAppData ToDomain(this WebAppDataDto dto)
	{
		return new WebAppData(
			dto.Data,
			dto.ButtonText
		);
	}

	public static ProximityAlertTriggered ToDomain(this ProximityAlertTriggeredDto dto)
	{
		return new ProximityAlertTriggered(
			dto.Traveler.ToDomain(),
			dto.Watcher.ToDomain(),
			dto.Distance
		);
	}

	public static MessageAutoDeleteTimerChanged ToDomain(this MessageAutoDeleteTimerChangedDto dto)
	{
		return new MessageAutoDeleteTimerChanged(
			dto.MessageAutoDeleteTime
		);
	}

	public static ForumTopicCreated ToDomain(this ForumTopicCreatedDto dto)
	{
		return new ForumTopicCreated(
			dto.Name,
			dto.IconColor,
			dto.IconCustomEmojiId
		);
	}

	public static ChatShared ToDomain(this ChatSharedDto dto)
	{
		return new ChatShared(
			dto.RequestId,
			dto.ChatId
		);
	}

	public static WriteAccessAllowed ToDomain(this WriteAccessAllowedDto dto)
	{
		return new WriteAccessAllowed(
			default, //dto.FromRequest,
			dto.WebAppName,
			default //dto.FromAttachmentMenu
		);
	}

	public static VideoChatScheduled ToDomain(this VideoChatScheduledDto dto)
	{
		return new VideoChatScheduled(
			dto.StartDate
		);
	}

	public static VideoChatParticipantsInvited ToDomain(this VideoChatParticipantsInvitedDto dto)
	{
		return new VideoChatParticipantsInvited(
			dto.Users.Select(ToDomain).ToList()
		);
	}

	public static UserProfilePhotos ToDomain(this UserProfilePhotosDto dto)
	{
		return new UserProfilePhotos(
			dto.TotalCount,
			dto.Photos.Select(ToDomain).ToList()
		);
	}

	public static WebAppInfo ToDomain(this WebAppInfoDto dto)
	{
		return new WebAppInfo(
			dto.Url
		);
	}

	public static ReplyKeyboardMarkup ToDomain(this ReplyKeyboardMarkupDto dto)
	{
		return new ReplyKeyboardMarkup(
			dto.Keyboard.Select(ToDomain).ToList(),
			dto.IsPersistent,
			dto.ResizeKeyboard,
			dto.OneTimeKeyboard,
			dto.InputFieldPlaceholder,
			dto.Selective
		);
	}

	public static KeyboardButton ToDomain(this KeyboardButtonDto dto)
	{
		return new KeyboardButton(
			dto.Text,
			dto.RequestUser?.ToDomain(),
			dto.RequestChat?.ToDomain(),
			dto.RequestContact,
			dto.RequestLocation,
			dto.RequestPoll?.ToDomain(),
			dto.WebApp?.ToDomain()
		);
	}

	public static KeyboardButtonRequestUser ToDomain(this KeyboardButtonRequestUserDto dto)
	{
		return new KeyboardButtonRequestUser(
			dto.RequestId,
			dto.UserIsBot,
			dto.UserIsPremium
		);
	}

	public static KeyboardButtonRequestChat ToDomain(this KeyboardButtonRequestChatDto dto)
	{
		return new KeyboardButtonRequestChat(
			dto.RequestId,
			dto.ChatIsChannel,
			dto.ChatIsForum,
			dto.ChatHasUsername,
			dto.ChatIsCreated,
			dto.UserAdministratorRights?.ToDomain(),
			dto.BotAdministratorRights?.ToDomain(),
			dto.BotIsMember
		);
	}

	public static KeyboardButtonPollType ToDomain(this KeyboardButtonPollTypeDto dto)
	{
		return new KeyboardButtonPollType(
			dto.Type
		);
	}

	public static ReplyKeyboardRemove ToDomain(this ReplyKeyboardRemoveDto dto)
	{
		return new ReplyKeyboardRemove(
			dto.RemoveKeyboard,
			dto.Selective
		);
	}

	public static InlineKeyboardMarkup ToDomain(this InlineKeyboardMarkupDto dto)
	{
		return new InlineKeyboardMarkup(
			dto.InlineKeyboard.Select(ToDomain).ToList()
		);
	}

	public static InlineKeyboardButton ToDomain(this InlineKeyboardButtonDto dto)
	{
		return new InlineKeyboardButton(
			dto.Text,
			dto.Url,
			dto.CallbackData,
			dto.WebApp?.ToDomain(),
			new LoginUrl(), //dto.LoginUrl,
			dto.SwitchInlineQuery,
			dto.SwitchInlineQueryCurrentChat,
			dto.SwitchInlineQueryChosenChat?.ToDomain(),
			new CallbackGame(), //dto.CallbackGame,
			dto.Pay
		);
	}

	public static SwitchInlineQueryChosenChat ToDomain(this SwitchInlineQueryChosenChatDto dto)
	{
		return new SwitchInlineQueryChosenChat(
			dto.Query,
			dto.AllowUserChats,
			dto.AllowBotChats,
			dto.AllowGroupChats,
			dto.AllowChannelChats
		);
	}

	public static CallbackQuery ToDomain(this CallbackQueryDto dto)
	{
		return new CallbackQuery(
			dto.Id,
			dto.From.ToDomain(),
			dto.Message?.ToDomain(),
			dto.InlineMessageId,
			dto.ChatInstance,
			dto.Data,
			dto.GameShortName
		);
	}

	public static ForceReply ToDomain(this ForceReplyDto dto)
	{
		return new ForceReply(
			dto.ForceReply,
			dto.InputFieldPlaceholder,
			dto.Selective
		);
	}

	public static ChatPhoto ToDomain(this ChatPhotoDto dto)
	{
		return new ChatPhoto(
			dto.SmallFileId,
			dto.SmallFileUniqueId,
			dto.BigFileId,
			dto.BigFileUniqueId
		);
	}

	public static ChatInviteLink ToDomain(this ChatInviteLinkDto dto)
	{
		return new ChatInviteLink(
			dto.InviteLink,
			dto.Creator.ToDomain(),
			dto.CreatesJoinRequest,
			dto.IsPrimary,
			dto.IsRevoked,
			dto.Name,
			dto.ExpireDate,
			dto.MemberLimit,
			dto.PendingJoinRequestCount
		);
	}

	public static ChatAdministratorRights ToDomain(this ChatAdministratorRightsDto dto)
	{
		return new ChatAdministratorRights(
			dto.IsAnonymous,
			dto.CanManageChat,
			dto.CanDeleteMessages,
			dto.CanManageVideoChats,
			dto.CanRestrictMembers,
			dto.CanPromoteMembers,
			dto.CanChangeInfo,
			dto.CanInviteUsers,
			dto.CanPostMessages,
			dto.CanEditMessages,
			dto.CanPinMessages,
			default, //dto.CanPostStories,
			default, //dto.CanEditStories,
			default, //dto.CanDeleteStories,
			dto.CanManageTopics
		);
	}

	public static ChatMemberOwner ToDomain(this ChatMemberOwnerDto dto)
	{
		return new ChatMemberOwner(
			dto.Status,
			dto.User.ToDomain(),
			dto.IsAnonymous,
			dto.CustomTitle
		);
	}

	public static ChatMemberAdministrator ToDomain(this ChatMemberAdministratorDto dto)
	{
		return new ChatMemberAdministrator(
			dto.Status,
			dto.User.ToDomain(),
			dto.CanBeEdited,
			dto.IsAnonymous,
			dto.CanManageChat,
			dto.CanDeleteMessages,
			dto.CanManageVideoChats,
			dto.CanRestrictMembers,
			dto.CanPromoteMembers,
			dto.CanChangeInfo,
			dto.CanInviteUsers,
			dto.CanPostMessages,
			dto.CanEditMessages,
			dto.CanPinMessages,
			default, //dto.CanPostStories,
			default, //dto.CanEditStories,
			default, //dto.CanDeleteStories,
			dto.CanManageTopics,
			dto.CustomTitle
		);
	}

	public static ChatMemberMember ToDomain(this ChatMemberMemberDto dto)
	{
		return new ChatMemberMember(
			dto.Status,
			dto.User.ToDomain()
		);
	}

	public static ChatMemberRestricted ToDomain(this ChatMemberRestrictedDto dto)
	{
		return new ChatMemberRestricted(
			dto.Status,
			dto.User.ToDomain(),
			dto.IsMember,
			dto.CanSendMessages,
			dto.CanSendAudios,
			dto.CanSendDocuments,
			dto.CanSendPhotos,
			dto.CanSendVideos,
			dto.CanSendVideoNotes,
			dto.CanSendVoiceNotes,
			dto.CanSendPolls,
			dto.CanSendOtherMessages,
			dto.CanAddWebPagePreviews,
			dto.CanChangeInfo,
			dto.CanInviteUsers,
			dto.CanPinMessages,
			dto.CanManageTopics,
			dto.UntilDate
		);
	}

	public static ChatMemberLeft ToDomain(this ChatMemberLeftDto dto)
	{
		return new ChatMemberLeft(
			dto.Status,
			dto.User.ToDomain()
		);
	}

	public static ChatMemberBanned ToDomain(this ChatMemberBannedDto dto)
	{
		return new ChatMemberBanned(
			dto.Status,
			dto.User.ToDomain(),
			dto.UntilDate
		);
	}

	public static ChatMemberUpdated ToDomain(this ChatMemberUpdatedDto dto)
	{
		return new ChatMemberUpdated(
			dto.Chat.ToDomain(),
			dto.From.ToDomain(),
			dto.Date,
			new ChatMember(), //dto.OldChatMember,
			new ChatMember(), //dto.NewChatMember,
			dto.InviteLink?.ToDomain(),
			dto.ViaChatFolderInviteLink
		);
	}

	public static ChatJoinRequest ToDomain(this ChatJoinRequestDto dto)
	{
		return new ChatJoinRequest(
			dto.Chat.ToDomain(),
			dto.From.ToDomain(),
			dto.UserChatId,
			dto.Date,
			dto.Bio,
			dto.InviteLink?.ToDomain()
		);
	}

	public static ChatPermissions ToDomain(this ChatPermissionsDto dto)
	{
		return new ChatPermissions(
			dto.CanSendMessages,
			dto.CanSendAudios,
			dto.CanSendDocuments,
			dto.CanSendPhotos,
			dto.CanSendVideos,
			dto.CanSendVideoNotes,
			dto.CanSendVoiceNotes,
			dto.CanSendPolls,
			dto.CanSendOtherMessages,
			dto.CanAddWebPagePreviews,
			dto.CanChangeInfo,
			dto.CanInviteUsers,
			dto.CanPinMessages,
			dto.CanManageTopics
		);
	}

	public static ChatLocation ToDomain(this ChatLocationDto dto)
	{
		return new ChatLocation(
			dto.Location.ToDomain(),
			dto.Address
		);
	}

	public static ForumTopic ToDomain(this ForumTopicDto dto)
	{
		return new ForumTopic(
			dto.MessageThreadId,
			dto.Name,
			dto.IconColor,
			dto.IconCustomEmojiId
		);
	}

	public static BotCommand ToDomain(this BotCommandDto dto)
	{
		return new BotCommand(
			dto.Command,
			dto.Description
		);
	}

	public static BotCommandScopeDefault ToDomain(this BotCommandScopeDefaultDto dto)
	{
		return new BotCommandScopeDefault(
			dto.Type
		);
	}

	public static BotCommandScopeAllPrivateChats ToDomain(this BotCommandScopeAllPrivateChatsDto dto)
	{
		return new BotCommandScopeAllPrivateChats(
			dto.Type
		);
	}

	public static BotCommandScopeAllGroupChats ToDomain(this BotCommandScopeAllGroupChatsDto dto)
	{
		return new BotCommandScopeAllGroupChats(
			dto.Type
		);
	}

	public static BotCommandScopeAllChatAdministrators ToDomain(this BotCommandScopeAllChatAdministratorsDto dto)
	{
		return new BotCommandScopeAllChatAdministrators(
			dto.Type
		);
	}

	public static BotCommandScopeChat ToDomain(this BotCommandScopeChatDto dto)
	{
		return new BotCommandScopeChat(
			dto.Type,
			TryLongParse(dto.ChatId, out var result) ? result : dto.ChatId.ToString()
		);
	}
	
	public static BotCommandScopeChatAdministrators ToDomain(this BotCommandScopeChatAdministratorsDto dto)
	{
		return new BotCommandScopeChatAdministrators(
			dto.Type,
			TryLongParse(dto.ChatId, out var result) ? result : dto.ChatId.ToString()
		);
	}

	public static BotCommandScopeChatMember ToDomain(this BotCommandScopeChatMemberDto dto)
	{
		return new BotCommandScopeChatMember(
			dto.Type,
			TryLongParse(dto.ChatId, out var result) ? result : dto.ChatId.ToString(),
			dto.UserId
		);
	}
	
	private static bool TryLongParse(ChatIdentifier chatIdentifier, out long result)
	{
		return long.TryParse(chatIdentifier.ToString(), out result);
	}

	public static BotName ToDomain(this BotNameDto dto)
	{
		return new BotName(
			dto.Name
		);
	}

	public static BotDescription ToDomain(this BotDescriptionDto dto)
	{
		return new BotDescription(
			dto.Description
		);
	}

	public static BotShortDescription ToDomain(this BotShortDescriptionDto dto)
	{
		return new BotShortDescription(
			dto.ShortDescription
		);
	}

	public static MenuButtonCommands ToDomain(this MenuButtonCommandsDto dto)
	{
		return new MenuButtonCommands(
			dto.Type
		);
	}

	public static MenuButtonWebApp ToDomain(this MenuButtonWebAppDto dto)
	{
		return new MenuButtonWebApp(
			dto.Type,
			dto.Text,
			dto.WebApp.ToDomain()
		);
	}

	public static MenuButtonDefault ToDomain(this MenuButtonDefaultDto dto)
	{
		return new MenuButtonDefault(
			dto.Type
		);
	}

	public static ResponseParameters ToDomain(this ResponseParametersDto dto)
	{
		return new ResponseParameters(
			dto.MigrateToChatId,
			dto.RetryAfter
		);
	}

	public static InputMediaPhoto ToDomain(this InputMediaPhotoDto dto)
	{
		return new InputMediaPhoto(
			dto.Type,
			dto.Media,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.HasSpoiler
		);
	}

	public static InputMediaVideo ToDomain(this InputMediaVideoDto dto)
	{
		return new InputMediaVideo(
			dto.Type,
			dto.Media,
			default, //dto.Thumbnail,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.Width,
			dto.Height,
			dto.Duration,
			dto.SupportsStreaming,
			dto.HasSpoiler
		);
	}

	public static InputMediaAnimation ToDomain(this InputMediaAnimationDto dto)
	{
		return new InputMediaAnimation(
			dto.Type,
			dto.Media,
			default, //dto.Thumbnail,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.Width,
			dto.Height,
			dto.Duration,
			dto.HasSpoiler
		);
	}

	public static InputMediaAudio ToDomain(this InputMediaAudioDto dto)
	{
		return new InputMediaAudio(
			dto.Type,
			dto.Media,
			default, //dto.Thumbnail,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.Duration,
			dto.Performer,
			dto.Title
		);
	}

	public static InputMediaDocument ToDomain(this InputMediaDocumentDto dto)
	{
		return new InputMediaDocument(
			dto.Type,
			dto.Media,
			default, //dto.Thumbnail,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.DisableContentTypeDetection
		);
	}

	public static Sticker ToDomain(this StickerDto dto)
	{
		return new Sticker(
			dto.FileId,
			dto.FileUniqueId,
			dto.Type,
			dto.Width,
			dto.Height,
			dto.IsAnimated,
			dto.IsVideo,
			dto.Thumbnail?.ToDomain(),
			dto.Emoji,
			dto.SetName,
			new TelegramFile(), //dto.PremiumAnimation,
			dto.MaskPosition?.ToDomain(),
			dto.CustomEmojiId,
			dto.NeedsRepainting,
			dto.FileSize
		);
	}

	public static StickerSet ToDomain(this StickerSetDto dto)
	{
		return new StickerSet(
			dto.Name,
			dto.Title,
			dto.StickerType,
			dto.IsAnimated,
			dto.IsVideo,
			dto.Stickers.Select(ToDomain).ToList(),
			default //dto.Thumbnail,
		);
	}

	public static MaskPosition ToDomain(this MaskPositionDto dto)
	{
		return new MaskPosition(
			dto.Point,
			dto.XShift,
			dto.YShift,
			dto.Scale
		);
	}

	public static InputSticker ToDomain(this InputStickerDto dto)
	{
		return new InputSticker(
			default, //dto.Sticker,
			dto.EmojiList,
			dto.MaskPosition?.ToDomain(),
			dto.Keywords
		);
	}

	public static InlineQuery ToDomain(this InlineQueryDto dto)
	{
		return new InlineQuery(
			dto.Id,
			dto.From.ToDomain(),
			dto.Query,
			dto.Offset,
			dto.ChatType,
			dto.Location?.ToDomain()
		);
	}

	public static InlineQueryResultsButton ToDomain(this InlineQueryResultsButtonDto dto)
	{
		return new InlineQueryResultsButton(
			dto.Text,
			dto.WebApp?.ToDomain(),
			dto.StartParameter
		);
	}

	public static InlineQueryResultArticle ToDomain(this InlineQueryResultArticleDto dto)
	{
		return new InlineQueryResultArticle(
			dto.Type,
			dto.Id,
			dto.Title,
			default, //TODO: dto.InputMessageContent,
			dto.ReplyMarkup?.ToDomain(),
			dto.Url,
			dto.HideUrl,
			dto.Description,
			dto.ThumbnailUrl,
			dto.ThumbnailWidth,
			dto.ThumbnailHeight
		);
	}

	public static InlineQueryResultPhoto ToDomain(this InlineQueryResultPhotoDto dto)
	{
		return new InlineQueryResultPhoto(
			dto.Type,
			dto.Id,
			dto.PhotoUrl,
			dto.ThumbnailUrl,
			dto.PhotoWidth,
			dto.PhotoHeight,
			dto.Title,
			dto.Description,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultGif ToDomain(this InlineQueryResultGifDto dto)
	{
		return new InlineQueryResultGif(
			dto.Type,
			dto.Id,
			dto.GifUrl,
			dto.GifWidth,
			dto.GifHeight,
			dto.GifDuration,
			dto.ThumbnailUrl,
			dto.ThumbnailMimeType,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultMpeg4Gif ToDomain(this InlineQueryResultMpeg4GifDto dto)
	{
		return new InlineQueryResultMpeg4Gif(
			dto.Type,
			dto.Id,
			dto.Mpeg4Url,
			dto.Mpeg4Width,
			dto.Mpeg4Height,
			dto.Mpeg4Duration,
			dto.ThumbnailUrl,
			dto.ThumbnailMimeType,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultAudio ToDomain(this InlineQueryResultAudioDto dto)
	{
		return new InlineQueryResultAudio(
			dto.Type,
			dto.Id,
			dto.AudioUrl,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.Performer,
			dto.AudioDuration,
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultVoice ToDomain(this InlineQueryResultVoiceDto dto)
	{
		return new InlineQueryResultVoice(
			dto.Type,
			dto.Id,
			dto.VoiceUrl,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.VoiceDuration,
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultDocument ToDomain(this InlineQueryResultDocumentDto dto)
	{
		return new InlineQueryResultDocument(
			dto.Type,
			dto.Id,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.DocumentUrl,
			dto.MimeType,
			dto.Description,
			dto.ReplyMarkup?.ToDomain(),
			default, //TODO: dto.InputMessageContent,
			dto.ThumbnailUrl,
			dto.ThumbnailWidth,
			dto.ThumbnailHeight
		);
	}

	public static InlineQueryResultLocation ToDomain(this InlineQueryResultLocationDto dto)
	{
		return new InlineQueryResultLocation(
			dto.Type,
			dto.Id,
			dto.Latitude,
			dto.Longitude,
			dto.Title,
			dto.HorizontalAccuracy,
			dto.LivePeriod,
			dto.Heading,
			dto.ProximityAlertRadius,
			dto.ReplyMarkup?.ToDomain(),
			default, //TODO: dto.InputMessageContent,
			dto.ThumbnailUrl,
			dto.ThumbnailWidth,
			dto.ThumbnailHeight
		);
	}

	public static InlineQueryResultVenue ToDomain(this InlineQueryResultVenueDto dto)
	{
		return new InlineQueryResultVenue(
			dto.Type,
			dto.Id,
			dto.Latitude,
			dto.Longitude,
			dto.Title,
			dto.Address,
			dto.FoursquareId,
			dto.FoursquareType,
			dto.GooglePlaceId,
			dto.GooglePlaceType,
			dto.ReplyMarkup?.ToDomain(),
			default, //TODO: dto.InputMessageContent,
			dto.ThumbnailUrl,
			dto.ThumbnailWidth,
			dto.ThumbnailHeight
		);
	}

	public static InlineQueryResultContact ToDomain(this InlineQueryResultContactDto dto)
	{
		return new InlineQueryResultContact(
			dto.Type,
			dto.Id,
			dto.PhoneNumber,
			dto.FirstName,
			dto.LastName,
			dto.Vcard,
			dto.ReplyMarkup?.ToDomain(),
			default, //TODO: dto.InputMessageContent,
			dto.ThumbnailUrl,
			dto.ThumbnailWidth,
			dto.ThumbnailHeight
		);
	}

	public static InlineQueryResultGame ToDomain(this InlineQueryResultGameDto dto)
	{
		return new InlineQueryResultGame(
			dto.Type,
			dto.Id,
			dto.GameShortName,
			dto.ReplyMarkup?.ToDomain()
		);
	}

	public static InlineQueryResultCachedPhoto ToDomain(this InlineQueryResultCachedPhotoDto dto)
	{
		return new InlineQueryResultCachedPhoto(
			dto.Type,
			dto.Id,
			dto.PhotoFileId,
			dto.Title,
			dto.Description,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedGif ToDomain(this InlineQueryResultCachedGifDto dto)
	{
		return new InlineQueryResultCachedGif(
			dto.Type,
			dto.Id,
			dto.GifFileId,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedMpeg4Gif ToDomain(this InlineQueryResultCachedMpeg4GifDto dto)
	{
		return new InlineQueryResultCachedMpeg4Gif(
			dto.Type,
			dto.Id,
			dto.Mpeg4FileId,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedSticker ToDomain(this InlineQueryResultCachedStickerDto dto)
	{
		return new InlineQueryResultCachedSticker(
			dto.Type,
			dto.Id,
			dto.StickerFileId,
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedDocument ToDomain(this InlineQueryResultCachedDocumentDto dto)
	{
		return new InlineQueryResultCachedDocument(
			dto.Type,
			dto.Id,
			dto.Title,
			dto.DocumentFileId,
			dto.Description,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedVideo ToDomain(this InlineQueryResultCachedVideoDto dto)
	{
		return new InlineQueryResultCachedVideo(
			dto.Type,
			dto.Id,
			dto.VideoFileId,
			dto.Title,
			dto.Description,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedVoice ToDomain(this InlineQueryResultCachedVoiceDto dto)
	{
		return new InlineQueryResultCachedVoice(
			dto.Type,
			dto.Id,
			dto.VoiceFileId,
			dto.Title,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InlineQueryResultCachedAudio ToDomain(this InlineQueryResultCachedAudioDto dto)
	{
		return new InlineQueryResultCachedAudio(
			dto.Type,
			dto.Id,
			dto.AudioFileId,
			dto.Caption,
			dto.ParseMode,
			dto.CaptionEntities?.Select(ToDomain).ToList(),
			dto.ReplyMarkup?.ToDomain(),
			default //TODO: dto.InputMessageContent,
		);
	}

	public static InputTextMessageContent ToDomain(this InputTextMessageContentDto dto)
	{
		return new InputTextMessageContent(
			dto.MessageText,
			dto.ParseMode,
			dto.Entities?.Select(ToDomain).ToList(),
			dto.DisableWebPagePreview
		);
	}

	public static InputLocationMessageContent ToDomain(this InputLocationMessageContentDto dto)
	{
		return new InputLocationMessageContent(
			dto.Latitude,
			dto.Longitude,
			dto.HorizontalAccuracy,
			dto.LivePeriod,
			dto.Heading,
			dto.ProximityAlertRadius
		);
	}

	public static InputVenueMessageContent ToDomain(this InputVenueMessageContentDto dto)
	{
		return new InputVenueMessageContent(
			dto.Latitude,
			dto.Longitude,
			dto.Title,
			dto.Address,
			dto.FoursquareId,
			dto.FoursquareType,
			dto.GooglePlaceId,
			dto.GooglePlaceType
		);
	}

	public static InputContactMessageContent ToDomain(this InputContactMessageContentDto dto)
	{
		return new InputContactMessageContent(
			dto.PhoneNumber,
			dto.FirstName,
			dto.LastName,
			dto.Vcard
		);
	}

	public static InputInvoiceMessageContent ToDomain(this InputInvoiceMessageContentDto dto)
	{
		return new InputInvoiceMessageContent(
			dto.Title,
			dto.Description,
			dto.Payload,
			dto.ProviderToken,
			dto.Currency,
			dto.Prices?.Select(ToDomain).ToList(),
			dto.MaxTipAmount,
			dto.SuggestedTipAmounts,
			dto.ProviderData,
			dto.PhotoUrl,
			dto.PhotoSize,
			dto.PhotoWidth,
			dto.PhotoHeight,
			dto.NeedName,
			dto.NeedPhoneNumber,
			dto.NeedEmail,
			dto.NeedShippingAddress,
			dto.SendPhoneNumberToProvider,
			dto.SendEmailToProvider,
			dto.IsFlexible
		);
	}

	public static ChosenInlineResult ToDomain(this ChosenInlineResultDto dto)
	{
		return new ChosenInlineResult(
			dto.ResultId,
			dto.From.ToDomain(),
			dto.Location?.ToDomain(),
			dto.InlineMessageId,
			dto.Query
		);
	}

	public static SentWebAppMessage ToDomain(this SentWebAppMessageDto dto)
	{
		return new SentWebAppMessage(
			dto.InlineMessageId
		);
	}

	public static LabeledPrice ToDomain(this LabeledPriceDto dto)
	{
		return new LabeledPrice(
			dto.Label,
			dto.Amount
		);
	}

	public static Invoice ToDomain(this InvoiceDto dto)
	{
		return new Invoice(
			dto.Title,
			dto.Description,
			dto.StartParameter,
			dto.Currency,
			dto.TotalAmount
		);
	}

	public static ShippingAddress ToDomain(this ShippingAddressDto dto)
	{
		return new ShippingAddress(
			dto.CountryCode,
			dto.State,
			dto.City,
			dto.StreetLine1,
			dto.StreetLine2,
			dto.PostCode
		);
	}

	public static OrderInfo ToDomain(this OrderInfoDto dto)
	{
		return new OrderInfo(
			dto.Name,
			dto.PhoneNumber,
			dto.Email,
			dto.ShippingAddress?.ToDomain()
		);
	}

	public static ShippingOption ToDomain(this ShippingOptionDto dto)
	{
		return new ShippingOption(
			dto.Id,
			dto.Title,
			dto.Prices.Select(ToDomain).ToList()
		);
	}

	public static SuccessfulPayment ToDomain(this SuccessfulPaymentDto dto)
	{
		return new SuccessfulPayment(
			dto.Currency,
			dto.TotalAmount,
			dto.InvoicePayload,
			dto.ShippingOptionId,
			dto.OrderInfo?.ToDomain(),
			dto.TelegramPaymentChargeId,
			dto.ProviderPaymentChargeId
		);
	}

	public static ShippingQuery ToDomain(this ShippingQueryDto dto)
	{
		return new ShippingQuery(
			dto.Id,
			dto.From.ToDomain(),
			dto.InvoicePayload,
			dto.ShippingAddress.ToDomain()
		);
	}

	public static PreCheckoutQuery ToDomain(this PreCheckoutQueryDto dto)
	{
		return new PreCheckoutQuery(
			dto.Id,
			dto.From.ToDomain(),
			dto.Currency,
			dto.TotalAmount,
			dto.InvoicePayload,
			dto.ShippingOptionId,
			dto.OrderInfo?.ToDomain()
		);
	}

	public static PassportData ToDomain(this PassportDataDto dto)
	{
		return new PassportData(
			dto.Data.Select(ToDomain).ToList(),
			dto.Credentials.ToDomain()
		);
	}

	public static PassportFile ToDomain(this PassportFileDto dto)
	{
		return new PassportFile(
			dto.FileId,
			dto.FileUniqueId,
			dto.FileSize,
			dto.FileDate
		);
	}

	public static EncryptedPassportElement ToDomain(this EncryptedPassportElementDto dto)
	{
		return new EncryptedPassportElement(
			dto.Type,
			dto.Data,
			dto.PhoneNumber,
			dto.Email,
			dto.Files?.Select(ToDomain).ToList(),
			dto.FrontSide?.ToDomain(),
			dto.ReverseSide?.ToDomain(),
			dto.Selfie?.ToDomain(),
			dto.Translation?.Select(ToDomain).ToList(),
			dto.Hash
		);
	}

	public static EncryptedCredentials ToDomain(this EncryptedCredentialsDto dto)
	{
		return new EncryptedCredentials(
			dto.Data,
			dto.Hash,
			dto.Secret
		);
	}

	public static PassportElementErrorDataField ToDomain(this PassportElementErrorDataFieldDto dto)
	{
		return new PassportElementErrorDataField(
			dto.Source,
			dto.Type,
			dto.FieldName,
			dto.DataHash,
			dto.Message
		);
	}

	public static PassportElementErrorFrontSide ToDomain(this PassportElementErrorFrontSideDto dto)
	{
		return new PassportElementErrorFrontSide(
			dto.Source,
			dto.Type,
			dto.FileHash,
			dto.Message
		);
	}

	public static PassportElementErrorReverseSide ToDomain(this PassportElementErrorReverseSideDto dto)
	{
		return new PassportElementErrorReverseSide(
			dto.Source,
			dto.Type,
			dto.FileHash,
			dto.Message
		);
	}

	public static PassportElementErrorSelfie ToDomain(this PassportElementErrorSelfieDto dto)
	{
		return new PassportElementErrorSelfie(
			dto.Source,
			dto.Type,
			dto.FileHash,
			dto.Message
		);
	}

	public static PassportElementErrorFile ToDomain(this PassportElementErrorFileDto dto)
	{
		return new PassportElementErrorFile(
			dto.Source,
			dto.Type,
			dto.FileHash,
			dto.Message
		);
	}

	public static PassportElementErrorFiles ToDomain(this PassportElementErrorFilesDto dto)
	{
		return new PassportElementErrorFiles(
			dto.Source,
			dto.Type,
			dto.FileHashes,
			dto.Message
		);
	}

	public static PassportElementErrorTranslationFile ToDomain(this PassportElementErrorTranslationFileDto dto)
	{
		return new PassportElementErrorTranslationFile(
			dto.Source,
			dto.Type,
			dto.FileHash,
			dto.Message
		);
	}

	public static PassportElementErrorTranslationFiles ToDomain(this PassportElementErrorTranslationFilesDto dto)
	{
		return new PassportElementErrorTranslationFiles(
			dto.Source,
			dto.Type,
			dto.FileHashes,
			dto.Message
		);
	}

	public static PassportElementErrorUnspecified ToDomain(this PassportElementErrorUnspecifiedDto dto)
	{
		return new PassportElementErrorUnspecified(
			dto.Source,
			dto.Type,
			dto.ElementHash,
			dto.Message
		);
	}

	public static Game ToDomain(this GameDto dto)
	{
		return new Game(
			dto.Title,
			dto.Description,
			dto.Photo.Select(ToDomain).ToList(),
			dto.Text,
			dto.TextEntities?.Select(ToDomain).ToList(),
			dto.Animation?.ToDomain()
		);
	}

	public static GameHighScore ToDomain(this GameHighScoreDto dto)
	{
		return new GameHighScore(
			dto.Position,
			dto.User.ToDomain(),
			dto.Score
		);
	}

}