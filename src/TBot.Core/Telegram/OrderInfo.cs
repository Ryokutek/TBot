namespace TBot.Core.Telegram;

public class OrderInfo
{
	public string? Name { get; set; }
	public string? PhoneNumber { get; set; }
	public string? Email { get; set; }
	public ShippingAddress? ShippingAddress { get; set; }

	public OrderInfo(
		string? name,
		string? phoneNumber,
		string? email,
		ShippingAddress? shippingAddress)
	{
		Name = name;
		PhoneNumber = phoneNumber;
		Email = email;
		ShippingAddress = shippingAddress;
	}
}