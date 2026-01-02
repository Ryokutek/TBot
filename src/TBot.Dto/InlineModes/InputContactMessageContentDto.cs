using System.Text.Json.Serialization;

namespace TBot.Dto.InlineModes;

/// <summary>
/// Represents the content of a contact message to be sent as the result of an inline query.
/// </summary>
public abstract class InputContactMessageContentDto
{
	/// <summary>
	/// Contact's phone number
	/// </summary>
	[JsonPropertyName("phone_number")]
	public string PhoneNumber { get; set; } = null!;

	/// <summary>
	/// Contact's first name
	/// </summary>
	[JsonPropertyName("first_name")]
	public string FirstName { get; set; } = null!;

	/// <summary>
	/// Optional. Contact's last name
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes
	/// </summary>
	[JsonPropertyName("vcard")]
	public string? Vcard { get; set; }
}