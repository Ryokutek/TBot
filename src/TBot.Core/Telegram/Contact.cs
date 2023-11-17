namespace TBot.Core.Telegram;

public class Contact
{
	public string PhoneNumber { get; set; }
	public string FirstName { get; set; }
	public string? LastName { get; set; }
	public int? UserId { get; set; }
	public string? Vcard { get; set; }

	public Contact(
		string phoneNumber,
		string firstName,
		string? lastName,
		int? userId,
		string? vcard)
	{
		PhoneNumber = phoneNumber;
		FirstName = firstName;
		LastName = lastName;
		UserId = userId;
		Vcard = vcard;
	}
}