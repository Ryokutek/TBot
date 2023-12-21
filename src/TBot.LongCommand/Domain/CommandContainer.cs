using System.Diagnostics.CodeAnalysis;

namespace TBot.LongCommand.Domain;

public class CommandContainer
{
    public Dictionary<string, object?> State { get; set; } = new ();
    
    public virtual void AddOrUpdateState(string key, object? value)
    {
        if (!State.TryAdd(key, value))
        {
            State[key] = value;
        }
    }
    
    public virtual void SetState(Dictionary<string, object?> value)
    {
        State = value;
    }
    
    public virtual bool TryAddState(string key, object? value)
    {
        return State.TryAdd(key, value);
    }

    public virtual bool TryGetState(string key, out object? value)
    {
        return State.TryGetValue(key, out value);
    }
    
    public virtual bool TryGetState<T>(string key, [NotNullWhen(true)] out T? value)
    {
        State.TryGetValue(key, out var stateValue);

        if (stateValue is T castedValue)
        {
            value = castedValue;
            return true;
        }

        value = default;
        return false;
    }
}