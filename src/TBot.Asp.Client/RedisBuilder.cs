using Microsoft.Extensions.DependencyInjection;
using TBot.Core.ConfigureOptions;

namespace TBot.Asp.Client;

public class RedisBuilder
{
    private readonly TBotBuilder _botBuilder;
    private readonly IServiceCollection _serviceCollection;
    
    public RedisBuilder(TBotBuilder botBuilder, IServiceCollection serviceCollection)
    {
        _botBuilder = botBuilder;
        _serviceCollection = serviceCollection;
    }

    public TBotBuilder AddConnectionString(string connectionString)
    {
        _serviceCollection.Configure<RedisOptions>(options =>
        {
            options.ConnectionString = connectionString;
        });
        return _botBuilder;
    }
    
    public TBotBuilder AddConnectionString(RedisOptions redisOptions)
    {
        _serviceCollection.Configure<RedisOptions>(options =>
        {
            options.Host = redisOptions.Host;
            options.Password = redisOptions.Password;
            options.DefaultDatabase = redisOptions.DefaultDatabase;
            options.SyncTimeout = redisOptions.SyncTimeout;
        });
        return _botBuilder;
    }
}