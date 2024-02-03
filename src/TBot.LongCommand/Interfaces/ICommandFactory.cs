using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

public interface ICommandFactory
{
    bool TryGetCommandByTrigger(Update update, out CommandRepresentation? commandRepresentation);
    bool TryGetCommandByIdentifier(string commandIdentifier, out CommandRepresentation? commandRepresentation);
    CommandPart CreateCommandPart(CommandRepresentation commandRepresentation, int partNumber);
}