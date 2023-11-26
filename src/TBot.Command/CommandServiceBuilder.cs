using Microsoft.Extensions.DependencyInjection;
using TBot.CommandProcessor.Abstractions;
using TBot.Core.Builders;

namespace TBot.CommandProcessor;

public class CommandServiceBuilder
{
    public readonly UpdateEngineBuilder UpdateEngineBuilder;
    public readonly IServiceCollection Services;

    public CommandServiceBuilder(UpdateEngineBuilder updateEngineBuilder, IServiceCollection serviceCollection)
    {
        UpdateEngineBuilder = updateEngineBuilder;
        Services = serviceCollection;
    }

    public CommandServiceBuilder AddCommand<TCommandFactory>() where TCommandFactory : ICommandFactory
    {
        Services.AddTransient(typeof(ICommandFactory), typeof(TCommandFactory));
        return this;
    }
}