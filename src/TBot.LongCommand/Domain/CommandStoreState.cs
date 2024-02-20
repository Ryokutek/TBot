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

    public static CommandStoreState Create(CurrentRequest currentRequest, CommandDescriptor commandDescriptor)
    {
        return new CommandStoreState
        {
            SessionId = currentRequest.TraceId,
            ChatId = currentRequest.FromChatId,
            CommandIdentifier = commandDescriptor.CommandIdentifier,
            PartNumber = commandDescriptor.PartNumber,
            TotalParts = commandDescriptor.TotalParts,
            PartState = commandDescriptor.State
        };
    }
}