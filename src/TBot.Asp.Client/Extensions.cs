using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace TBot.Client.Asp;

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
    
    public static TBotLongPollingBuilder RunTBot(this IApplicationBuilder applicationBuilder)
    {
        return new TBotLongPollingBuilder(applicationBuilder.ApplicationServices);
    }
    
    public static TBotRouteBuilder UseTBotRoute(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return new TBotRouteBuilder(endpointRouteBuilder);
    }
}