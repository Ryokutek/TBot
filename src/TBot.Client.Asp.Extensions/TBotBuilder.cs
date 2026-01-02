using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBot.Client;
using TBot.Client.Services.CallLimiter;
using TBot.Client.Services.HttpRequests;
using TBot.Client.Services.LongPolling;
using TBot.Core;
using TBot.Core.CallLimiter.Interfaces;
using TBot.Core.ConfigureOptions;
using TBot.Core.LongPolling.Interfaces;
using TBot.Core.RequestManagement.Interfaces;
using TBot.Core.TBot.Interfaces;

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
    
    public TBotBuilder AddLongPolling()
    {
        _serviceCollection.AddTransient<ILongPollingService, LongPollingService>();
        return this;
    }

    private void ConfigureOptions()
    {
        _serviceCollection.AddOptions<TBotOptions>(_configuration, TBotOptions.OptionsName);
        _serviceCollection.AddOptions<CallLimiterOptions>(_configuration, $"{TBotOptions.OptionsName}:{CallLimiterOptions.OptionsName}");
        _serviceCollection.AddOptions<UpdateOptions>(_configuration, $"{TBotOptions.OptionsName}:{UpdateOptions.OptionsName}");
    }
}