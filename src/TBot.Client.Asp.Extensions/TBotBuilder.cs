using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBot.Client.Services.CallLimiter;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;
using TBot.Client.Services.UpdateEngine;
using TBot.Core.CallLimiter.Interfaces;
using TBot.Core.ConfigureOptions;
using TBot.Core.LongPolling.Interfaces;
using TBot.Core.RequestManagement.Interfaces;
using TBot.Core.TBot.Interfaces;
using TBot.Core.UpdateEngine;
using TBot.Core.UpdateEngine.Interfaces;

namespace TBot.Client.Asp.Extensions;

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
        _serviceCollection.AddScoped<ICallLimiterService, CallLimiterService>();
        return this;
    }
    
    public TBotBuilder AddLongPolling()
    {
        //TODO: Singleton
        _serviceCollection.AddTransient<ILongPollingService, LongPollingService>();
        return this;
    }
    
    public UpdateEngineBuilder AddUpdateEngine()
    {
        _serviceCollection.AddScoped<IUpdateEngineService, UpdateEngineService>();
        return new UpdateEngineBuilder(_serviceCollection);
    }

    private void ConfigureOptions()
    {
        _serviceCollection.AddOptions<TBotOptions>(_configuration, TBotOptions.OptionsName);
        _serviceCollection.AddOptions<CallLimiterOptions>(_configuration, $"{TBotOptions.OptionsName}:{CallLimiterOptions.OptionsName}");
        _serviceCollection.AddOptions<UpdateOptions>(_configuration, $"{TBotOptions.OptionsName}:{UpdateOptions.OptionsName}");
    }
}