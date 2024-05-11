namespace TBot.Core.CallLimiter;

public class CallLimitContext
{
    private const long BufferSecondTime = 1;
    public long Counter { get; set; }
    public int MaxCalls { get; init; }
    public TimeSpan Interval { get; init; }
    public TimeSpan WaitInterval { get; set; }
    public List<Call> Calls { get; set; } = new ();

    public void SaveCall(int messageCount)
    {
        for (var i = 0; i < messageCount; i++)
        {
            Calls.Add(new Call
            {
                Id = Counter++,
                Time = GetUtcNowUnixTimeSeconds()
            });
        }
    }

    public void Clear()
    {
        WaitInterval = TimeSpan.Zero;
        Calls.Clear();
    }

    public bool HasNext(int messageCount)
    {
        return GetFreshCalls(GetUtcNowUnixTimeSeconds()).Count + messageCount < MaxCalls;
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
        WaitInterval = waitInterval.TotalSeconds < 0 ? TimeSpan.Zero : waitInterval;
        return WaitInterval;
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
    public long Id { get; set; }
    public long Time { get; set; }
}