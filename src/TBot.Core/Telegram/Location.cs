namespace TBot.Core.Telegram;

public class Location
{
	public float Longitude { get; set; }
	public float Latitude { get; set; }
	public float? HorizontalAccuracy { get; set; }
	public int? LivePeriod { get; set; }
	public int? Heading { get; set; }
	public int? ProximityAlertRadius { get; set; }

	public Location(
		float longitude,
		float latitude,
		float? horizontalAccuracy,
		int? livePeriod,
		int? heading,
		int? proximityAlertRadius)
	{
		Longitude = longitude;
		Latitude = latitude;
		HorizontalAccuracy = horizontalAccuracy;
		LivePeriod = livePeriod;
		Heading = heading;
		ProximityAlertRadius = proximityAlertRadius;
	}
}