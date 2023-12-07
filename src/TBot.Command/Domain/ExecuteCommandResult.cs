namespace TBot.Command.Domain;

public class ExecuteCommandResult
{
    public CommandDescriptor CommandDescriptor { get; init; } = null!;
    public CommandContainer CommandContainer { get; init; } = null!;
}