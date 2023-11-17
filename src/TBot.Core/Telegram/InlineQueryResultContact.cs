namespace TBot.Core.Telegram;

public class InlineQueryResultContact
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string PhoneNumber { get; set; }
	public string FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Vcard { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }
	public string? ThumbnailUrl { get; set; }
	public int? ThumbnailWidth { get; set; }
	public int? ThumbnailHeight { get; set; }

	public InlineQueryResultContact(
		string type,
		string id,
		string phoneNumber,
		string firstName,
		string? lastName,
		string? vcard,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent,
		string? thumbnailUrl,
		int? thumbnailWidth,
		int? thumbnailHeight)
	{
		Type = type;
		Id = id;
		PhoneNumber = phoneNumber;
		FirstName = firstName;
		LastName = lastName;
		Vcard = vcard;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailWidth = thumbnailWidth;
		ThumbnailHeight = thumbnailHeight;
	}
}