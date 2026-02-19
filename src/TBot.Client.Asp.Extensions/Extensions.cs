using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace TBot.Client.Asp.Extensions;

public static class Extensions
{
    extension(WebApplicationBuilder applicationBuilder)
    {
        public IServiceCollection AddTBot()
        {
            _ = new TBotBuilder(applicationBuilder);
            return applicationBuilder.Services;
        }

        public IServiceCollection AddTBot(Action<TBotBuilder> option)
        {
            option(new TBotBuilder(applicationBuilder));
            return applicationBuilder.Services;
        }
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