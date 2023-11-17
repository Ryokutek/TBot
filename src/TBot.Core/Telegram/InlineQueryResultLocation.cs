namespace TBot.Core.Telegram;

public class InlineQueryResultLocation
{
	public string Type { get; set; }
	public string Id { get; set; }
	public float Latitude { get; set; }
	public float Longitude { get; set; }
	public string Title { get; set; }
	public float? HorizontalAccuracy { get; set; }
	public int? LivePeriod { get; set; }
	public int? Heading { get; set; }
	public int? ProximityAlertRadius { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }
	public string? ThumbnailUrl { get; set; }
	public int? ThumbnailWidth { get; set; }
	public int? ThumbnailHeight { get; set; }

	public InlineQueryResultLocation(
		string type,
		string id,
		float latitude,
		float longitude,
		string title,
		float? horizontalAccuracy,
		int? livePeriod,
		int? heading,
		int? proximityAlertRadius,
		InlineKeyboardMarkup? replyMarkup,
		InputMessageContent? inputMessageContent,
		string? thumbnailUrl,
		int? thumbnailWidth,
		int? thumbnailHeight)
	{
		Type = type;
		Id = id;
		Latitude = latitude;
		Longitude = longitude;
		Title = title;
		HorizontalAccuracy = horizontalAccuracy;
		LivePeriod = livePeriod;
		Heading = heading;
		ProximityAlertRadius = proximityAlertRadius;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailWidth = thumbnailWidth;
		ThumbnailHeight = thumbnailHeight;
	}
}