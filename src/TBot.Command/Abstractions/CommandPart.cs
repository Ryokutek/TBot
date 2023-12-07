using TBot.Command.Domain;

namespace TBot.Command.Abstractions;

public abstract class CommandPart
{
    private CommandContext? _context;
    protected CommandContext Context => _context ?? throw new Exception("Command context not set.");

    private CommandContainer? _container;
    protected CommandContainer Container => _container ?? throw new Exception("Command container not set.");
    
    public bool IsCommandPartCompleted { get; private set; }
    
    public void Init(CommandContext context, CommandContainer container)
    {
        _context ??= context;
        _container ??= container;
    }

    protected abstract Task SendActionRequestAsync();
    protected abstract Task ProcessAnswerAsync();
    protected virtual Task SendRepeatActionRequestAsync()
    {
        return Task.CompletedTask;
    }

    public async Task ExecuteActionRequestAsync()
    {
        await SendActionRequestAsync();
    }

    public async Task ExecuteProcessAnswerAsync()
    {
        try
        {
            await ProcessAnswerAsync();
            IsCommandPartCompleted = true;
        }
        catch
        {
            await SendRepeatActionRequestAsync();
        }
    }
}