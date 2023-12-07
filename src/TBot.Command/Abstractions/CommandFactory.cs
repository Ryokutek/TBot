using Microsoft.Extensions.DependencyInjection;
using TBot.Command.Interfaces;

namespace TBot.Command.Abstractions;

public class CommandFactory : ICommandFactory, IDisposable
{
    private bool _disposed;
    private readonly IServiceScope _serviceScope;
    private readonly Dictionary<string, SortedDictionary<int, CommandPartModel>> _commands;

    public CommandFactory(
        IServiceProvider serviceProvider, 
        Dictionary<string, SortedDictionary<int, CommandPartModel>> commands)
    {
        _commands = commands;
        _serviceScope = serviceProvider.CreateScope();
    }

    public bool IsCommandExist(string name)
    {
        return _commands.ContainsKey(name);
    }
    
    public int GetTotalParts(string name)
    {
        return _commands[name].Count;
    }

    public CommandPart CreateCommandPart(string name, int partNumber)
    {
        var type = _commands[name][partNumber].Type;
        return (CommandPart)ActivatorUtilities.CreateInstance(_serviceScope.ServiceProvider, type);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _serviceScope.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}