using TBot.Core.TBot.EnvironmentManagement;

namespace TBot.LongCommand.Domain;

public class CommandStoreState
{
    public Guid SessionId { get; set; }
    public long ChatId { get; set; }
    public string CommandIdentifier { get; set; } = null!;
    public int PartNumber { get; set; }
    public int TotalParts { get; set; }
    public CommandPartState PartState { get; set; }

    public static CommandStoreState Create(UserSession userSession, CommandDescriptor commandDescriptor)
    {
        return new CommandStoreState
        {
            SessionId = userSession.Id,
            ChatId = userSession.ChatId,
            CommandIdentifier = commandDescriptor.CommandIdentifier,
            PartNumber = commandDescriptor.PartNumber,
            TotalParts = commandDescriptor.TotalParts,
            PartState = commandDescriptor.State
        };
    }
}