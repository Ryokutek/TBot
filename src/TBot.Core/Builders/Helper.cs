using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TBot.Core.Builders;

public static class Helper
{
    public static void AddOptions<TOptions>(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration,
        string optionSection) where TOptions : class
    {
        var configurationSection = configuration.GetSection(optionSection);
        serviceCollection.Configure<TOptions>(configurationSection);
    }
}