namespace TBot.Core.ConfigureOptions;

public class RedisOptions
{
    public const string OptionsName = "RedisOptions";
    
    public string Host { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int DefaultDatabase { get; set; }
    public long SyncTimeout { get; set; }

    public override string ToString()
    {
        return $"{Host},password={Password},defaultDatabase={DefaultDatabase},syncTimeout={SyncTimeout}";
    }
}