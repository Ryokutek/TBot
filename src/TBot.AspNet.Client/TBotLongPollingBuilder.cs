using Microsoft.Extensions.DependencyInjection;
using TBot.Core.LongPolling;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;

namespace TBot.AspNet.Client;

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
    
    public IServiceProvider WithUpdateEngine(CancellationToken? cancellationToken = null)
    {
        var longPollingService = _serviceProvider.GetRequiredService<ILongPollingService>();
        
        longPollingService.Start(async update =>
        {
            await using var scope = _serviceProvider.CreateAsyncScope();
            var updateEngineService = scope.ServiceProvider.GetRequiredService<IUpdateEngineService>();
            await updateEngineService.StartAsync(update);
        }, cancellationToken);
        
        return _serviceProvider;
    }
}