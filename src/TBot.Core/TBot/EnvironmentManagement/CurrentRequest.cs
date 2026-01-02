namespace TBot.Core.TBot.EnvironmentManagement;

public class CurrentRequest
{
    public Guid TraceId { get; private set; }
    public long ChatId { get; private set; }
    public long UserId { get; private set; }

    private CurrentRequest(Guid traceId, long chatId, long userId)
    {
        TraceId = traceId;
        ChatId = chatId;
        UserId = userId;
    }

    public static CurrentRequest Create(Guid id, long chatId, long userId)
    {
        return new CurrentRequest(id, chatId, userId);
    }

    public static CurrentRequest CreateEmpty()
    {
        return new CurrentRequest(Guid.Empty, 0, 0);
    }
}