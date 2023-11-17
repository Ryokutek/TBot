namespace TBot.Core.Telegram;

public class ProximityAlertTriggered
{
	public User Traveler { get; set; }
	public User Watcher { get; set; }
	public int Distance { get; set; }

	public ProximityAlertTriggered(User traveler, User watcher, int distance)
	{
		Traveler = traveler;
		Watcher = watcher;
		Distance = distance;
	}
}