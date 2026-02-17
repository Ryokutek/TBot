using System.Text.Json.Serialization;

namespace TBot.Dto.Types;

/// <summary>
/// Describes data required for decrypting and authenticating EncryptedPassportElement. See the Telegram Passport Documentation for a complete description of the data decryption and authentication processes.
/// </summary>
public class EncryptedCredentialsDto
{
	/// <summary>
	/// Base64-encoded encrypted JSON-serialized data with unique user's payload, data hashes and secrets required for EncryptedPassportElement decryption and authentication
	/// </summary>
	[JsonPropertyName("data")]
	public string Data { get; set; } = null!;

	/// <summary>
	/// Base64-encoded data hash for data authentication
	/// </summary>
	[JsonPropertyName("hash")]
	public string Hash { get; set; } = null!;

	/// <summary>
	/// Base64-encoded secret, encrypted with the bot's public RSA key, required for data decryption
	/// </summary>
	[JsonPropertyName("secret")]
	public string Secret { get; set; } = null!;
}