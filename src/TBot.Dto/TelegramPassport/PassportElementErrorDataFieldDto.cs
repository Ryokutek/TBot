using System.Text.Json.Serialization;

namespace TBot.Dto.TelegramPassport;

/// <summary>
/// Represents an issue in one of the data fields that was provided by the user. The error is considered resolved when the field's value changes.
/// </summary>
public abstract class PassportElementErrorDataFieldDto
{
	/// <summary>
	/// Error source, must be data
	/// </summary>
	[JsonPropertyName("source")]
	public string Source { get; set; } = null!;

	/// <summary>
	/// The section of the user's Telegram Passport which has the error, one of “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport”, “address”
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = null!;

	/// <summary>
	/// Name of the data field which has the error
	/// </summary>
	[JsonPropertyName("field_name")]
	public string FieldName { get; set; } = null!;

	/// <summary>
	/// Base64-encoded data hash
	/// </summary>
	[JsonPropertyName("data_hash")]
	public string DataHash { get; set; } = null!;

	/// <summary>
	/// Error message
	/// </summary>
	[JsonPropertyName("message")]
	public string Message { get; set; } = null!;
}