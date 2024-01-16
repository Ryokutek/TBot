using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBot.Client;
using TBot.Client.Services.CallLimiter;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;
using TBot.Client.Services.UpdateEngine;
using TBot.Client.Stores;
using TBot.Core.Builders;
using TBot.Core.CallLimiter;
using TBot.Core.ConfigureOptions;
using TBot.Core.HttpRequests;
using TBot.Core.LongPolling;
using TBot.Core.Stores;
using TBot.Core.TBot;
using TBot.Core.UpdateEngine;

namespace TBot.Asp.Client;

// ReSharper disable once InconsistentNaming
public class TBotBuilder
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IConfiguration _configuration;

    public TBotBuilder(WebApplicationBuilder webApplicationBuilder)
    {
        _serviceCollection = webApplicationBuilder.Services;
        _configuration = webApplicationBuilder.Configuration;

        ConfigureOptions();
        
        _serviceCollection
            .AddHttpClient<IRequestService, TBotRequestService>().Services
            .AddTransient<ITBotClient, TBotClient>();
    }

    public TBotBuilder EnableCallLimiter()
    {
        _serviceCollection.AddTransient<ICallLimiterService, CallLimiterService>();
        return this;
    }

    public TBotBuilder AddRedisStore(string connectionString)
    {
        _serviceCollection.Configure<RedisOptions>(options =>
        {
            options.ConnectionString = connectionString;
        });
        AddRedisService();
        return this;
    }
    
    public TBotBuilder AddRedisStore(RedisOptions redisOptions)
    {
        _serviceCollection.Configure<RedisOptions>(options =>
        {
            options.Host = redisOptions.Host;
            options.Password = redisOptions.Password;
            options.DefaultDatabase = redisOptions.DefaultDatabase;
            options.SyncTimeout = redisOptions.SyncTimeout;
        });
        AddRedisService();
        return this;
    }

    private void AddRedisService()
    {
        _serviceCollection.AddTransient<ITBotStore, RedisTBotStore>();
    }
    
    public TBotBuilder AddLongPoll()
    {
        _serviceCollection.AddTransient<ILongPollingService, LongPollingService>();
        return this;
    }

    public UpdateEngineBuilder AddUpdateServices()
    {
        _serviceCollection.AddScoped<IUpdateEngineService, UpdateEngineService>();
        return new UpdateEngineBuilder(_serviceCollection, _configuration);
    }
    
    private void ConfigureOptions()
    {
        _serviceCollection.AddOptions<TBotOptions>(_configuration, TBotOptions.OptionsName);
        _serviceCollection.AddOptions<CallLimiterOptions>(_configuration, $"{TBotOptions.OptionsName}:{CallLimiterOptions.OptionsName}");
        _serviceCollection.AddOptions<UpdateOptions>(_configuration, $"{TBotOptions.OptionsName}:{UpdateOptions.OptionsName}");
    }
}