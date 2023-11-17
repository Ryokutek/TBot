namespace TBot.Core.Telegram;

public class InputLocationMessageContent
{
	public float Latitude { get; set; }
	public float Longitude { get; set; }
	public float? HorizontalAccuracy { get; set; }
	public int? LivePeriod { get; set; }
	public int? Heading { get; set; }
	public int? ProximityAlertRadius { get; set; }

	public InputLocationMessageContent(
		float latitude,
		float longitude,
		float? horizontalAccuracy,
		int? livePeriod,
		int? heading,
		int? proximityAlertRadius)
	{
		Latitude = latitude;
		Longitude = longitude;
		HorizontalAccuracy = horizontalAccuracy;
		LivePeriod = livePeriod;
		Heading = heading;
		ProximityAlertRadius = proximityAlertRadius;
	}
}