using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;

namespace TBot.LongCommand.Builder;

public class CommandConstructor
{
    private readonly CommandServiceBuilder _commandServiceBuilder;
    public string CommandIdentifier { get; set; }
    public Predicate<Update> CommandTrigger { get; set; }
    public Dictionary<int, CommandPartModel> Parts { get; set; } = new ();
    
    public CommandConstructor(string commandIdentifier, Predicate<Update> commandTrigger, CommandServiceBuilder commandServiceBuilder)
    {
        CommandIdentifier = commandIdentifier;
        CommandTrigger = commandTrigger;
        _commandServiceBuilder = commandServiceBuilder;
    }

    public CommandConstructor AddPart<TCommandPart>(string? name = null) where TCommandPart : CommandPart
    {
        int position;
        if (!Parts.Any()) {
            position = 0;
        }
        else {
            position = Parts.OrderByDescending(x => x.Key).FirstOrDefault().Key + 1;
        }

        var partType = typeof(TCommandPart);
        Parts.Add(position, CommandPartModel.Create(name ?? partType.Name, partType));
        return this;
    }

    public CommandServiceBuilder Build()
    {
        return _commandServiceBuilder.Save(this);
    }
}