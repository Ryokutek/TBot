using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TBot.Core.ConfigureOptions;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Dto.Updates;

namespace TBot.Client.Asp.Extensions;

// ReSharper disable once InconsistentNaming
public class TBotRouteBuilder(IEndpointRouteBuilder endpointRouteBuilder)
{
    public IEndpointConventionBuilder With(
        [StringSyntax("Route")] string pattern, 
        Func<HttpContext, IServiceProvider, UpdateDto, Task> handler)
    {
        using var scope = endpointRouteBuilder.ServiceProvider.CreateScope();
        return UseTBot(endpointRouteBuilder, pattern, endpointRouteBuilder.ServiceProvider, handler);
    }

    public IEndpointConventionBuilder With(Func<HttpContext, IServiceProvider, UpdateDto, Task> handler)
    {
        using var scope = endpointRouteBuilder.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        return UseTBot(endpointRouteBuilder, pattern, endpointRouteBuilder.ServiceProvider, handler);
    }
    
    public IEndpointConventionBuilder WithUpdateEngine()
    {
        using var scope = endpointRouteBuilder.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        
        return UseTBot(endpointRouteBuilder, pattern, endpointRouteBuilder.ServiceProvider, 
            async (_, serviceProvider, update) =>
            {
                await using var innerScope = serviceProvider.CreateAsyncScope();
            });
    }
    
    private static IEndpointConventionBuilder UseTBot(
        IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern,
        IServiceProvider serviceProvider,
        Func<HttpContext, IServiceProvider, UpdateDto, Task> handler)
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
                    
                    logger?.LogDebug("Received an update from Telegram. UpdateId: {UpdateId}", updateDto.UpdateId);
                    using (TBotEnvironment.SetRequest(updateDto.ToSession()))
                    {
                        await handler(context, serviceProvider, updateDto);
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