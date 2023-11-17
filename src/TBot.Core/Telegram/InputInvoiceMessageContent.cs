namespace TBot.Core.Telegram;

public class InputInvoiceMessageContent
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string Payload { get; set; }
	public string ProviderToken { get; set; }
	public string Currency { get; set; }
	public List<LabeledPrice> Prices { get; set; }
	public int? MaxTipAmount { get; set; }
	public List<int> SuggestedTipAmounts { get; set; }
	public string? ProviderData { get; set; }
	public string? PhotoUrl { get; set; }
	public int? PhotoSize { get; set; }
	public int? PhotoWidth { get; set; }
	public int? PhotoHeight { get; set; }
	public bool? NeedName { get; set; }
	public bool? NeedPhoneNumber { get; set; }
	public bool? NeedEmail { get; set; }
	public bool? NeedShippingAddress { get; set; }
	public bool? SendPhoneNumberToProvider { get; set; }
	public bool? SendEmailToProvider { get; set; }
	public bool? IsFlexible { get; set; }

	public InputInvoiceMessageContent(
		string title,
		string description,
		string payload,
		string providerToken,
		string currency,
		List<LabeledPrice> prices,
		int? maxTipAmount,
		List<int> suggestedTipAmounts,
		string? providerData,
		string? photoUrl,
		int? photoSize,
		int? photoWidth,
		int? photoHeight,
		bool? needName,
		bool? needPhoneNumber,
		bool? needEmail,
		bool? needShippingAddress,
		bool? sendPhoneNumberToProvider,
		bool? sendEmailToProvider,
		bool? isFlexible)
	{
		Title = title;
		Description = description;
		Payload = payload;
		ProviderToken = providerToken;
		Currency = currency;
		Prices = prices;
		MaxTipAmount = maxTipAmount;
		SuggestedTipAmounts = suggestedTipAmounts;
		ProviderData = providerData;
		PhotoUrl = photoUrl;
		PhotoSize = photoSize;
		PhotoWidth = photoWidth;
		PhotoHeight = photoHeight;
		NeedName = needName;
		NeedPhoneNumber = needPhoneNumber;
		NeedEmail = needEmail;
		NeedShippingAddress = needShippingAddress;
		SendPhoneNumberToProvider = sendPhoneNumberToProvider;
		SendEmailToProvider = sendEmailToProvider;
		IsFlexible = isFlexible;
	}
}