using Microsoft.Extensions.DependencyInjection;
using TBot.Core.Builders;
using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;
using TBot.LongCommand.Interfaces;

namespace TBot.LongCommand.Builder;

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

    public CommandConstructor Add(string commandIdentifier, Predicate<Update> commandTrigger)
    {
        return new CommandConstructor(commandIdentifier, commandTrigger, this);
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
            return new CommandFactory(provider, _commandConstructors.Select(x=>new CommandRepresentation
            {
                CommandIdentifier = x.CommandIdentifier,
                CommandParts = new SortedDictionary<int, CommandPartModel>(x.Parts),
                CommandTrigger = x.CommandTrigger
            }).ToList());
        });

        return this;
    }
}