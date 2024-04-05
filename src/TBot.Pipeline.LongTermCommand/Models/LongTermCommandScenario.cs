using TBot.Core.Telegram;

namespace TBot.Pipeline.LongTermCommand;

public class LongTermCommandScenario
{
    public string Identifier { get; private set; }
    public List<Predicate<Update>> Triggers { get; private set; } = new ();
    public List<Type> Segments { get; private set; } = new();

    public LongTermCommandScenario(string identifier)
    {
        Identifier = identifier;
    }
    
    public void AddTrigger(Predicate<Update> trigger)
    {
        Triggers.Add(trigger);
    }
    
    public void AddCommandSegment<TCommandSegment>()
    {
        Segments.Add(typeof(TCommandSegment));
    }
    
    public void AddCommandSegment(Type segmentType)
    {
        Segments.Add(segmentType);
    }
}