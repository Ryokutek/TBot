namespace TBot.Core.Telegram;

public class InlineQueryResultVenue
{
	public string Type { get; set; }
	public string Id { get; set; }
	public float Latitude { get; set; }
	public float Longitude { get; set; }
	public string Title { get; set; }
	public string Address { get; set; }
	public string? FoursquareId { get; set; }
	public string? FoursquareType { get; set; }
	public string? GooglePlaceId { get; set; }
	public string? GooglePlaceType { get; set; }
	public InlineKeyboardMarkup? ReplyMarkup { get; set; }
	public InputMessageContent? InputMessageContent { get; set; }
	public string? ThumbnailUrl { get; set; }
	public int? ThumbnailWidth { get; set; }
	public int? ThumbnailHeight { get; set; }

	public InlineQueryResultVenue(
		string type,
		string id,
		float latitude,
		float longitude,
		string title,
		string address,
		string? foursquareId,
		string? foursquareType,
		string? googlePlaceId,
		string? googlePlaceType,
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
		Address = address;
		FoursquareId = foursquareId;
		FoursquareType = foursquareType;
		GooglePlaceId = googlePlaceId;
		GooglePlaceType = googlePlaceType;
		ReplyMarkup = replyMarkup;
		InputMessageContent = inputMessageContent;
		ThumbnailUrl = thumbnailUrl;
		ThumbnailWidth = thumbnailWidth;
		ThumbnailHeight = thumbnailHeight;
	}
}