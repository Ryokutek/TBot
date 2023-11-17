using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Routing;
using TBot.Core.LongPolling;
using TBot.Core.Options;
using TBot.Core.TBot.RequestIdentification;
using TBot.Core.Telegram;
using TBot.Telegram.Dto.Updates;

namespace TBot.Client.AspNet;

public static class Extensions
{
    public static IServiceCollection AddTBot(this WebApplicationBuilder applicationBuilder)
    {
        _ = new TBotBuilder(applicationBuilder);
        return applicationBuilder.Services;
    }
    
    public static IServiceCollection AddTBot(this WebApplicationBuilder applicationBuilder, Action<TBotBuilder> option)
    {
        option(new TBotBuilder(applicationBuilder));
        return applicationBuilder.Services;
    }
    
    public static IServiceProvider RunTBotLongPoll(
        this IApplicationBuilder applicationBuilder, 
        Func<IServiceProvider, Update, Task> updateAction,
        CancellationToken? cancellationToken = null)
    {
        var service = applicationBuilder.ApplicationServices.GetRequiredService<ILongPollingService>();
        service.Start(dto => updateAction(applicationBuilder.ApplicationServices, dto), cancellationToken);
        return applicationBuilder.ApplicationServices;
    }
    
    public static IEndpointConventionBuilder UseTBot(
        this IEndpointRouteBuilder endpoints,
        Func<HttpContext, IServiceProvider, UpdateDto, Task> handler)
    {
        using var scope = endpoints.ServiceProvider.CreateScope();
        var pattern = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TBotOptions>>().Value.UpdatePath;
        return endpoints.UseTBot(pattern, endpoints.ServiceProvider, handler);
    }
    
    private static IEndpointConventionBuilder UseTBot(
        this IEndpointRouteBuilder endpoints,
        [StringSyntax("Route")] string pattern,
        IServiceProvider serviceProvider,
        Func<HttpContext, IServiceProvider, UpdateDto, Task> handler)
    {
        return endpoints.MapPost(pattern,
            async context =>
            {
                var updateDto = await JsonSerializer.DeserializeAsync<UpdateDto>(context.Request.Body);
                if (updateDto == null) {
                    throw new BadHttpRequestException("Couldn't deserialize an update dto.");
                }

                using (CurrentSessionThread.SetSession(Session.Create(Guid.NewGuid(), updateDto.Message!.Chat.Id)))
                {
                    await handler(context, serviceProvider, updateDto);
                } //TODO: Consider the origin of the update in the Domain model
            });
    }
}