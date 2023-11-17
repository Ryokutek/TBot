namespace TBot.Core.Telegram;

public class ChatLocation
{
	public Location Location { get; set; }
	public string Address { get; set; }

	public ChatLocation(Location location, string address)
	{
		Location = location;
		Address = address;
	}
}