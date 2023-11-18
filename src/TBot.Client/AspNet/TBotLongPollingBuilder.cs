using Microsoft.Extensions.DependencyInjection;
using TBot.Core.LongPolling;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.Client.AspNet;

// ReSharper disable once InconsistentNaming
public class TBotLongPollingBuilder
{
    private readonly IServiceProvider _serviceProvider;

    public TBotLongPollingBuilder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IServiceProvider With(Func<IServiceProvider, Update, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        var service = _serviceProvider.GetRequiredService<ILongPollingService>();
        service.Start(dto => updateAction(_serviceProvider, dto), cancellationToken);
        return _serviceProvider;
    }
    
    public IServiceProvider WithUpdateEngine(Func<IServiceProvider, Update, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        var longPollingService = _serviceProvider.GetRequiredService<ILongPollingService>();
        var updateEngineService = _serviceProvider.GetRequiredService<IUpdateEngineService>();
        
        longPollingService.Start(async update => await updateEngineService.StartAsync(update), cancellationToken);
        return _serviceProvider;
    }
}