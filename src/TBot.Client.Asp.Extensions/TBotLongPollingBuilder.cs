using Microsoft.Extensions.DependencyInjection;
using TBot.Core.LongPolling.Interfaces;
using TBot.Core.UpdateEngine;
using TBot.Dto.Updates;

namespace TBot.Asp.Client;

// ReSharper disable once InconsistentNaming
public class TBotLongPollingBuilder(IServiceProvider serviceProvider)
{
    public IServiceProvider With(Func<IServiceProvider, UpdateDto, Task> updateAction, CancellationToken? cancellationToken = null)
    {
        var service = serviceProvider.GetRequiredService<ILongPollingService>();
        service.StartPolling(dto => updateAction(serviceProvider, dto), cancellationToken);
        return serviceProvider;
    }
    
    public IServiceProvider WithUpdateEngine(CancellationToken? cancellationToken = null)
    {
        var longPollingService = serviceProvider.GetRequiredService<ILongPollingService>();
        
        longPollingService.StartPolling(async update =>
        {
            await using var scope = serviceProvider.CreateAsyncScope();
            var updateEngine = scope.ServiceProvider.GetRequiredService<IUpdateEngineService>();
            await updateEngine.ExecuteAsync(update);
        }, cancellationToken);
        
        return serviceProvider;
    }
}