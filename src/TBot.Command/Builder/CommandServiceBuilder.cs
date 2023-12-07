using Microsoft.Extensions.DependencyInjection;
using TBot.Command.Abstractions;
using TBot.Command.Interfaces;
using TBot.Core.Builders;

namespace TBot.Command.Builder;

public class CommandServiceBuilder
{
    public readonly UpdateEngineBuilder UpdateEngineBuilder;
    public readonly IServiceCollection Services;

    private readonly List<CommandConstructor> _commandConstructors = new ();
    
    public CommandServiceBuilder(UpdateEngineBuilder updateEngineBuilder, IServiceCollection serviceCollection)
    {
        UpdateEngineBuilder = updateEngineBuilder;
        Services = serviceCollection;
    }

    public CommandConstructor Add(string name)
    {
        return new CommandConstructor(name, this);
    }

    internal CommandServiceBuilder Save(CommandConstructor commandConstructor)
    {
        _commandConstructors.Add(commandConstructor);
        return this;
    }

    public CommandServiceBuilder Construct()
    {
        Services.AddTransient<ICommandFactory>(provider =>
        {
            var commands = _commandConstructors
                .ToDictionary(
                    commandConstructor => commandConstructor.Name,
                    commandConstructor => new SortedDictionary<int, CommandPartModel>(commandConstructor.Parts));

            return new CommandFactory(provider, commands);
        });

        return this;
    }
}