using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;

namespace TBot.LongCommand.Domain;

public class CommandRepresentation
{
    public string CommandIdentifier { get; set; } = null!;
    public Predicate<Update> CommandTrigger { get; set; } = null!;
    public SortedDictionary<int, CommandPartModel> CommandParts { get; set; } = new ();
}