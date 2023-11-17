namespace TBot.Core.Telegram;

public class ShippingAddress
{
	public string CountryCode { get; set; }
	public string State { get; set; }
	public string City { get; set; }
	public string StreetLine1 { get; set; }
	public string StreetLine2 { get; set; }
	public string PostCode { get; set; }

	public ShippingAddress(
		string countryCode,
		string state,
		string city,
		string streetLine1,
		string streetLine2,
		string postCode)
	{
		CountryCode = countryCode;
		State = state;
		City = city;
		StreetLine1 = streetLine1;
		StreetLine2 = streetLine2;
		PostCode = postCode;
	}
}