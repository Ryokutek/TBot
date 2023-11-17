namespace TBot.Core.Telegram;

public class InputVenueMessageContent
{
	public float Latitude { get; set; }
	public float Longitude { get; set; }
	public string Title { get; set; }
	public string Address { get; set; }
	public string? FoursquareId { get; set; }
	public string? FoursquareType { get; set; }
	public string? GooglePlaceId { get; set; }
	public string? GooglePlaceType { get; set; }

	public InputVenueMessageContent(
		float latitude,
		float longitude,
		string title,
		string address,
		string? foursquareId,
		string? foursquareType,
		string? googlePlaceId,
		string? googlePlaceType)
	{
		Latitude = latitude;
		Longitude = longitude;
		Title = title;
		Address = address;
		FoursquareId = foursquareId;
		FoursquareType = foursquareType;
		GooglePlaceId = googlePlaceId;
		GooglePlaceType = googlePlaceType;
	}
}