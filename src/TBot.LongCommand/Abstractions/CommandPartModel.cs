namespace TBot.LongCommand.Abstractions;

public class CommandPartModel
{
    public string Name { get; private set; }
    public Type Type { get; private set; }

    private CommandPartModel(string name, Type type)
    {
        Name = name;
        Type = type;
    }

    public static CommandPartModel Create(string name, Type type)
    {
        return new CommandPartModel(name, type);
    }
}