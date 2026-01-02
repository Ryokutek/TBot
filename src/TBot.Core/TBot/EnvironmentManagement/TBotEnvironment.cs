namespace TBot.Core.TBot.EnvironmentManagement;

// ReSharper disable once InconsistentNaming
public abstract class TBotEnvironment
{
    private static readonly AsyncLocal<CurrentRequest?> AsyncLocalCurrentRequest = new();
    
    public static CurrentRequest? CurrentRequest
    {
        get => AsyncLocalCurrentRequest.Value;
        set => AsyncLocalCurrentRequest.Value = value;
    }

    public static IDisposable SetRequest(CurrentRequest? currentRequest)
    {
        CurrentRequest = currentRequest;
        return new Disposable(() => { CurrentRequest = null; });
    }
}

public class Disposable : IDisposable
{
    private Action? _dispose;

    public Disposable(Action? dispose)
    {
        ArgumentNullException.ThrowIfNull(dispose);
        _dispose = dispose;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        _dispose?.Invoke();
        _dispose = null;
    }
}