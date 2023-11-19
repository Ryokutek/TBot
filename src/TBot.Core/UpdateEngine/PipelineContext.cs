using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class PipelineContext
{
    private PipelineCoordinator PipelineCoordinator { get; set; }
    private Dictionary<string, object?> State { get; set; } = new ();
    
    public Update Update { get; private set; }

    private PipelineContext(Update update)
    {
        Update = update;
        PipelineCoordinator = new PipelineCoordinator(this);
    }

    public static PipelineContext Create(Update update)
    {
        return new PipelineContext(update);
    }

    public PipelineCoordinator GetCoordinator()
    {
        return PipelineCoordinator;
    }

    public bool TryAddState(string key, object? value)
    {
        return State.TryAdd(key, value);
    }

    public bool TryGetState(string key, out object? value)
    {
        return State.TryGetValue(key, out value);
    }
}