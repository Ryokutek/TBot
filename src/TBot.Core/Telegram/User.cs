namespace TBot.Core.Telegram;

public class User
{
	public long Id { get; set; }
	public bool IsBot { get; set; }
	public string FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Username { get; set; }
	public string? LanguageCode { get; set; }
	public bool? IsPremium { get; set; }
	public bool? AddedToAttachmentMenu { get; set; }
	public bool? CanJoinGroups { get; set; }
	public bool? CanReadAllGroupMessages { get; set; }
	public bool? SupportsInlineQueries { get; set; }

	public User(
		long id,
		bool isBot,
		string firstName,
		string? lastName,
		string? username,
		string? languageCode,
		bool? isPremium,
		bool? addedToAttachmentMenu,
		bool? canJoinGroups,
		bool? canReadAllGroupMessages,
		bool? supportsInlineQueries)
	{
		Id = id;
		IsBot = isBot;
		FirstName = firstName;
		LastName = lastName;
		Username = username;
		LanguageCode = languageCode;
		IsPremium = isPremium;
		AddedToAttachmentMenu = addedToAttachmentMenu;
		CanJoinGroups = canJoinGroups;
		CanReadAllGroupMessages = canReadAllGroupMessages;
		SupportsInlineQueries = supportsInlineQueries;
	}
}