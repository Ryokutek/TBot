namespace TBot.Core.Telegram;

public class PassportData
{
	public List<EncryptedPassportElement> Data { get; set; }
	public EncryptedCredentials Credentials { get; set; }

	public PassportData(List<EncryptedPassportElement> data, EncryptedCredentials credentials)
	{
		Data = data;
		Credentials = credentials;
	}
}