using TBot.Core.TBot.RequestIdentification;

namespace TBot.LongCommand.Domain;

public class CommandStoreState
{
    public Guid SessionId { get; set; }
    public long ChatId { get; set; }
    public string CommandIdentifier { get; set; } = null!;
    public int PartNumber { get; set; }
    public int TotalParts { get; set; }
    public CommandPartState PartState { get; set; }

    public static CommandStoreState Create(Session session, CommandDescriptor commandDescriptor)
    {
        return new CommandStoreState
        {
            SessionId = session.Id,
            ChatId = session.ChatId,
            CommandIdentifier = commandDescriptor.CommandIdentifier,
            PartNumber = commandDescriptor.PartNumber,
            TotalParts = commandDescriptor.TotalParts,
            PartState = commandDescriptor.State
        };
    }
}