using TBot.Pipeline.LongTermCommand.Models;

namespace TBot.Pipeline.LongTermCommand;

public class LongTermCommand(string identifier, List<CommandSegment> segments)
{
    public string Identifier { get; private set; } = identifier;
    public List<CommandSegment> Segments { get; private set; } = segments;

    public string CurrentSegmentName { get; set; } = null!;
    public int CurrentSegmentNumber { get; set; } = -1;

    public void SetCurrentSegment(int number)
    {
        CurrentSegmentName = Segments[number].GetType().Name;
        CurrentSegmentNumber = number;
    }

    public CommandSegment GetCurrentSegment()
    {
        return Segments[CurrentSegmentNumber];
    }
    
    public void IncreaseSegmentNumber()
    {
        CurrentSegmentNumber++;
        CurrentSegmentName = Segments[CurrentSegmentNumber].GetType().Name;
    }
}