using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;

namespace TBot.Core.UpdateEngine;

public class Context
{
    protected Coordinator Coordinator { get; set; }
    public Dictionary<string, object?> State { get; set; } = new ();
    
    public Session Session { get; private set; }
    public Update Update { get; private set; }

    protected Context(Session session, Update update)
    {
        Session = session;
        Update = update;
        Coordinator = new Coordinator(this);
    }

    public static Context Create(Session session, Update update)
    {
        return new Context(session, update);
    }

    public virtual Coordinator GetCoordinator()
    {
        return Coordinator;
    }

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
}