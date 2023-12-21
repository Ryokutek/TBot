namespace TBot.LongCommand.Domain;

public class CommandDescriptor
{
    public string Name { get; private set; }
    public int PartNumber { get; private set; }
    public int TotalParts { get; private set; }
    public CommandPartState State { get; private set; }

    private CommandDescriptor(string name, int partNumber, int totalParts, CommandPartState state)
    {
        Name = name;
        PartNumber = partNumber;
        TotalParts = totalParts;
        State = state;
    }

    public static CommandDescriptor CreateNew(string name, int totalParts)
    {
        return new CommandDescriptor(name, 0, totalParts, CommandPartState.Action);
    }
    
    public static CommandDescriptor Create(string name, int part, int totalParts, CommandPartState state)
    {
        return new CommandDescriptor(name, part, totalParts, state);
    }

    public void SetProcessState()
    {
        State = CommandPartState.Process;
    }

    public void ResetState()
    {
        State = CommandPartState.Action;
    }
    
    public void IncrementPart()
    {
        if (!IsCommandComplete())
        {
            ResetState();
            PartNumber++;
        }
    }

    public bool IsCommandComplete()
    {
        return PartNumber == TotalParts;
    }
}