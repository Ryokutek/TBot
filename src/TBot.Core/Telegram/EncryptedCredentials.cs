namespace TBot.Core.Telegram;

public class EncryptedCredentials
{
	public string Data { get; set; }
	public string Hash { get; set; }
	public string Secret { get; set; }

	public EncryptedCredentials(string data, string hash, string secret)
	{
		Data = data;
		Hash = hash;
		Secret = secret;
	}
}