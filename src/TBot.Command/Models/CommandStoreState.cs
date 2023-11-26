namespace TBot.CommandProcessor.Models;

public class CommandStoreState
{
    public Guid SessionId { get; set; }
    public long ChatId { get; set; }
    public string CurrentCommandName { get; set; } = null!;
    public string CurrentStepName { get; set; } = null!;
    public string StepState { get; set; } = null!;
    public Dictionary<string, object?> State { get; set; } = new ();
}