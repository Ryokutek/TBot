namespace TBot.Core.TBot.RequestIdentification;

public class Session
{
    public Guid Id { get; private set; }
    public long ChatId { get; private set; }

    private Session(Guid id, long chatId)
    {
        Id = id;
        ChatId = chatId;
    }

    public static Session Create(Guid id, long chatId)
    {
        return new Session(id, chatId);
    }
}