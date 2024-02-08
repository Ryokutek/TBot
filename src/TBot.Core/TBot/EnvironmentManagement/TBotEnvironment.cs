namespace TBot.Core.TBot.EnvironmentManagement;

// ReSharper disable once InconsistentNaming
public class TBotEnvironment
{
    private static readonly AsyncLocal<UserSession?> AsyncLocalSession = new();
    
    public static UserSession? CurrentUser
    {
        get => AsyncLocalSession.Value;
        set => AsyncLocalSession.Value = value;
    }

    public static IDisposable SetSession(UserSession? session)
    {
        CurrentUser = session;
        return new Disposable(() => { CurrentUser = null; });
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