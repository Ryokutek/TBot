namespace TBot.Core.TBot.RequestIdentification;

public class CurrentSessionThread
{
    private static readonly AsyncLocal<Session?> AsyncLocalSession = new();
    
    public static Session? Session
    {
        get => AsyncLocalSession.Value;
        set => AsyncLocalSession.Value = value;
    }

    public static IDisposable SetSession(Session? session)
    {
        Session = session;
        return new Disposable(() => { Session = null; });
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