using Microsoft.Extensions.DependencyInjection;
using TBot.Core.UpdateEngine;
using TBot.Core.UpdateEngine.Interfaces;
using TBot.Dto.Updates;

namespace TBot.Client.Services.UpdateEngine;

public class UpdateEngineService(
    IServiceProvider serviceProvider,
    IEnumerable<IUpdateTrigger> updateTriggers) : IUpdateEngineService
{
    public async Task ExecuteAsync(UpdateDto updateDto)
    {
        var handlerTypes = new List<Type>();
        var context = UpdateContext.Create(updateDto);
        
        foreach (var trigger in updateTriggers)
        {
            if (await trigger.CheckAsync(context))
                handlerTypes.Add(trigger.HandlerType);
        }

        await using var scope = serviceProvider.CreateAsyncScope();
        foreach (var handlerType in handlerTypes)
        {
            var handler = (IUpdateHandler)ActivatorUtilities
                .GetServiceOrCreateInstance(scope.ServiceProvider, handlerType);

            await handler.ExecuteAsync(context, CancellationToken.None);
        }
    }
}