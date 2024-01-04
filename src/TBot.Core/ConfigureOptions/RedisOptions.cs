namespace TBot.Core.ConfigureOptions;

public class RedisOptions
{
    public string? Host { get; set; }
    public string? Password { get; set; }
    public int DefaultDatabase { get; set; }
    public long SyncTimeout { get; set; }

    private string? _connectionString;
    public string ConnectionString
    {
        get => _connectionString ?? $"{(string.IsNullOrEmpty(Host) ? throw new ArgumentException("Redis Host, cannot be empty!") : Host)}," +
            $"password={Password}," +
            $"defaultDatabase={DefaultDatabase}," +
            $"syncTimeout={SyncTimeout}";
        set => _connectionString = value;
    }

    public override string ToString()
    {
        return ConnectionString;
    }
}