namespace TBot.Dto.Types;

public class ChatIdentifier
{
    private readonly long? _identifier;
    private readonly string? _username;

    private ChatIdentifier(string username)
    {
        _username = username;
    }
        
    private ChatIdentifier(long identifier)
    {
        _identifier = identifier;
    }
        
    public static implicit operator ChatIdentifier(long identifier)
    {
        return new ChatIdentifier(identifier);
    }
        
    public static implicit operator ChatIdentifier(string username)
    {
        return new ChatIdentifier(username);
    }

    public override string ToString()
    {
        return _username ?? _identifier.ToString() ?? throw new Exception("Chat Id not set");
    }
}