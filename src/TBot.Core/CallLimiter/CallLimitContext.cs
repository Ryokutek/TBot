namespace TBot.Core.CallLimiter;

public class CallLimitContext
{
    private const long BufferSecondTime = 1;
    private uint Counter { get; set; }
    public int MaxCalls { get; init; }
    public TimeSpan Interval { get; init; }
    private List<Call> Calls { get; set; } = new ();

    public void SaveCall()
    {
        Calls.Add(new Call
        {
            Id = Counter++,
            Time = GetUtcNowUnixTimeSeconds()
        });
    }

    public void Clear()
    {
        Calls.Clear();
    }

    public bool HasNext()
    {
        return GetFreshCalls(GetUtcNowUnixTimeSeconds()).Count < MaxCalls;
    }

    public TimeSpan GetWaitInterval()
    {
        long utcNow = GetUtcNowUnixTimeSeconds();
        long? firstCallTime = GetFreshCalls(utcNow).FirstOrDefault()?.Time;
        
        if (!firstCallTime.HasValue)
        {
            return TimeSpan.Zero;
        }
        
        TimeSpan firstCallInterval = TimeSpan.FromSeconds(utcNow - firstCallTime.Value);
        TimeSpan waitInterval = Interval.Add(TimeSpan.FromSeconds(BufferSecondTime)) - firstCallInterval;
        return waitInterval.TotalSeconds < 0 ? TimeSpan.Zero : waitInterval;
    }

    private List<Call> GetFreshCalls(long utcNow)
    {
        long callInterval = utcNow - (int)Interval.TotalSeconds;
        return Calls.Where(x => x.Time >= callInterval).OrderBy(x=>x.Time).ToList();
    }

    private static long GetUtcNowUnixTimeSeconds()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
}

public class Call
{
    public uint Id { get; set; }
    public long Time { get; set; }
}