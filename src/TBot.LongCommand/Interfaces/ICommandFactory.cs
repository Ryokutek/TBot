using TBot.LongCommand.Abstractions;

namespace TBot.LongCommand.Interfaces;

public interface ICommandFactory
{
    bool IsCommandExist(string name);
    int GetTotalParts(string name);
    CommandPart CreateCommandPart(string name, int partNumber);
}