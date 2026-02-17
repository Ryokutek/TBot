using Microsoft.Extensions.DependencyInjection;
using TBot.Core.UpdateEngine;
using TBot.Dto.Updates;

namespace TBot.Client.Services.UpdateEngine;

public class UpdateEngineService(
    IServiceProvider serviceProvider,
    IEnumerable<IUpdateTrigger> updateTriggers) : IUpdateEngineService
{
    public async Task ExecuteAsync(UpdateDto updateDto)
    {
        var handlerTypes = new List<Type>();
        var context = new UpdateContext { UpdateDto = updateDto };
        
        foreach (var updateTrigger in updateTriggers)
        {
            var (isTriggered, handlerType) = await updateTrigger.CheckAsync(context);

            if (isTriggered) {
                handlerTypes.Add(handlerType);
            }
        }

        await using var scope = serviceProvider.CreateAsyncScope();
        foreach (var handlerType in handlerTypes)
        {
            var handler = (IUpdateHandler)ActivatorUtilities
                .GetServiceOrCreateInstance(scope.ServiceProvider, handlerType);

            await handler.ExecuteAsync(context);
        }
    }
}