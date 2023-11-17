namespace TBot.Core.Telegram;

public class ChatInviteLink
{
	public string InviteLink { get; set; }
	public User Creator { get; set; }
	public bool CreatesJoinRequest { get; set; }
	public bool IsPrimary { get; set; }
	public bool IsRevoked { get; set; }
	public string? Name { get; set; }
	public int? ExpireDate { get; set; }
	public int? MemberLimit { get; set; }
	public int? PendingJoinRequestCount { get; set; }

	public ChatInviteLink(
		string inviteLink,
		User creator,
		bool createsJoinRequest,
		bool isPrimary,
		bool isRevoked,
		string? name,
		int? expireDate,
		int? memberLimit,
		int? pendingJoinRequestCount)
	{
		InviteLink = inviteLink;
		Creator = creator;
		CreatesJoinRequest = createsJoinRequest;
		IsPrimary = isPrimary;
		IsRevoked = isRevoked;
		Name = name;
		ExpireDate = expireDate;
		MemberLimit = memberLimit;
		PendingJoinRequestCount = pendingJoinRequestCount;
	}
}