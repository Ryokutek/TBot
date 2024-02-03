using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

public interface ICommandFactory
{
    CommandRepresentation? GetCommandIfExists(Update update);
    CommandPart CreateCommandPart(CommandRepresentation commandRepresentation, int partNumber);
}