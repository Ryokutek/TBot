namespace TBot.Core.Telegram;

public class InputContactMessageContent
{
	public string PhoneNumber { get; set; }
	public string FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Vcard { get; set; }

	public InputContactMessageContent(
		string phoneNumber,
		string firstName,
		string? lastName,
		string? vcard)
	{
		PhoneNumber = phoneNumber;
		FirstName = firstName;
		LastName = lastName;
		Vcard = vcard;
	}
}