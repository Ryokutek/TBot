using TBot.Command.Abstractions;

namespace TBot.Command.Interfaces;

public interface ICommandFactory
{
    bool IsCommandExist(string name);
    int GetTotalParts(string name);
    CommandPart CreateCommandPart(string name, int partNumber);
}