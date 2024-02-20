namespace TBot.Core.TBot.EnvironmentManagement;

public class CurrentRequest
{
    public Guid TraceId { get; private set; }
    public long FromChatId { get; private set; }
    public long FromUserId { get; private set; }

    private CurrentRequest(Guid traceId, long fromChatId, long fromUserId)
    {
        TraceId = traceId;
        FromChatId = fromChatId;
        FromUserId = fromUserId;
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