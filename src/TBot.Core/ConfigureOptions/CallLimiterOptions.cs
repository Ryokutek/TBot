namespace TBot.Core.ConfigureOptions;

// ReSharper disable once InconsistentNaming
public class CallLimiterOptions
{
    public const string OptionsName = "CallLimiterOptions";
    
    public string StoreConnectionString { get; set; } = null!;
    public string StoreName { get; set; } = "Default";
    public int ThreadInitialCount { get; set; } = 20;
    public int ThreadMaxCount { get; set; } = 20;
    public int MaxCalls { get; set; } = 20;
    public TimeSpan CallsInterval { get; set; } = TimeSpan.FromSeconds(60);
    public TimeSpan ThreadTimeout { get; set; } = TimeSpan.FromSeconds(30);
    public TimeSpan StoreTimeout { get; set; } = TimeSpan.FromSeconds(2);
}