namespace TBot.Core.Telegram;

public class Venue
{
	public Location Location { get; set; }
	public string Title { get; set; }
	public string Address { get; set; }
	public string? FoursquareId { get; set; }
	public string? FoursquareType { get; set; }
	public string? GooglePlaceId { get; set; }
	public string? GooglePlaceType { get; set; }

	public Venue(
		Location location,
		string title,
		string address,
		string? foursquareId,
		string? foursquareType,
		string? googlePlaceId,
		string? googlePlaceType)
	{
		Location = location;
		Title = title;
		Address = address;
		FoursquareId = foursquareId;
		FoursquareType = foursquareType;
		GooglePlaceId = googlePlaceId;
		GooglePlaceType = googlePlaceType;
	}
}