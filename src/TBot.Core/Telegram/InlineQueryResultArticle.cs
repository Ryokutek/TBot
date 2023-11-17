namespace TBot.Core.Telegram;

public class InlineQueryResultArticle
{
	public string Type { get; set; }
	public string Id { get; set; }
	public string Title { get; set; }
	public InputMessageContent InputMessageContent { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public string? Url { get; set; }
	public bool? HideUrl { get; set; }
	public string? Description { get; set; }
	public string? ThumbnailUrl { get; set; }
	public int? ThumbnailWidth { get; set; }
	public int? ThumbnailHeight { get; set; }

	public InlineQueryResultArticle(
		string type,
		string id,
		string title,
		InputMessageContent inputMessageContent,
		InlineKeyboardMarkup? replyMarkup,
		string? url,
		bool? hideUrl,
		string? description,
		string? thumbnailUrl,
		int? thumbnailWidth,
		int? thumbnailHeight)
	{
		Type = type;
		Id = id;
		Title = title;
		InputMessageContent = inputMessageContent;
		ReplyMarkup = replyMarkup;
		Url = url;
		HideUrl = hideUrl;
		Description = description;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailWidth = thumbnailWidth;
		ThumbnailHeight = thumbnailHeight;
	}
}