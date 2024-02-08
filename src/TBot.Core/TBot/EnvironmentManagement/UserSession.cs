namespace TBot.Core.TBot.EnvironmentManagement;

public class UserSession
{
    public Guid Id { get; private set; }
    public long ChatId { get; private set; }
    public long UserId { get; private set; }

    private UserSession(Guid id, long chatId, long userId)
    {
        Id = id;
        ChatId = chatId;
        UserId = userId;
    }

    public static UserSession Create(Guid id, long chatId, long userId)
    {
        return new UserSession(id, chatId, userId);
    }

    public static UserSession CreateEmpty()
    {
        return new UserSession(Guid.Empty, 0, 0);
    }
}