namespace TBot.Core.Options;

public class UpdateOptions
{
    public const string OptionsName = "UpdateOptions";
    
    public int Limit { get; set; } = 0;
    public int TimeoutSeconds { get; set; } = 10;
}