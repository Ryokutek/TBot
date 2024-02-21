using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Client.Telegram;
using TBot.Client.Utilities;
using TBot.Core.ConfigureOptions;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;
using TBot.Dto.Updates;

namespace TBot.Asp.Client;

// ReSharper disable once InconsistentNaming
public class TBotRouteBuilder
{
    private readonly IEndpointRouteBuilder _endpointRouteBuilder;

    public TBotRouteBuilder(IEndpointRouteBuilder endpointRouteBuilder)
    {
        _endpointRouteBuilder = endpointRouteBuilder;
    }

    public IEndpointConventionBuilder With(
        [StringSyntax("Route")] string pattern, 
        Func<HttpContext, IServiceProvider, Update, Task> handler)
    {
        using var scope = _endpointRouteBuilder.ServiceProvider.CreateScope();
        return UseTBot(_endpointRouteBuilder, pattern, _endpointRouteBuilder.ServiceProvider, handler);
    }

    public IEndpointConventionBuilder With(Func<HttpContext, IServiceProvider, Update, Task> handler)
    {
        using var scope = _endpointRouteBuilder.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        return UseTBot(_endpointRouteBuilder, pattern, _endpointRouteBuilder.ServiceProvider, handler);
    }
    
    public IEndpointConventionBuilder WithUpdateEngine()
    {
        using var scope = _endpointRouteBuilder.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        
        return UseTBot(_endpointRouteBuilder, pattern, _endpointRouteBuilder.ServiceProvider, 
            async (_, serviceProvider, update) =>
            {
                await using var innerScope = serviceProvider.CreateAsyncScope();
                var updateEngineService = innerScope.ServiceProvider.GetRequiredService<IUpdateEngineService>();
                await updateEngineService.StartAsync(update);
            });
    }
    
    private static IEndpointConventionBuilder UseTBot(
        IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern,
        IServiceProvider serviceProvider,
        Func<HttpContext, IServiceProvider, Update, Task> handler)
    {
        return endpoints.MapPost(pattern,
            async context =>
            {
                var logger = serviceProvider.GetService<ILogger<TBotRouteBuilder>>();
                try
                {
                    var updateDto = await JsonSerializer.DeserializeAsync<UpdateDto>(context.Request.Body);
                    if (updateDto == null) {
                        throw new BadHttpRequestException($"Couldn't deserialize an update dto. RequestBody: {context.Request.Body}");
                    }
                    
                    var update = updateDto.ToDomain();
                    logger?.LogDebug("Received an update from Telegram. UpdateId: {UpdateId}", update.UpdateId);
                    using (TBotEnvironment.SetRequest(update.ToSession()))
                    {
                        await handler(context, serviceProvider, update);
                    }
                }
                catch (Exception e)
                {
                    logger?.LogCritical(e, "Update error.");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
            });
    }
}