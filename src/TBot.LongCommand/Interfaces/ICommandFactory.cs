using TBot.Core.Telegram;
using TBot.LongCommand.Abstractions;
using TBot.LongCommand.Domain;

namespace TBot.LongCommand.Interfaces;

public interface ICommandFactory
{
    bool IsCommandExistsByTrigger(Update update, out CommandRepresentation? commandRepresentation);
    bool IsCommandExistsByIdentifier(string commandIdentifier);
    CommandPart CreateCommandPart(string commandIdentifier, int partNumber);
}