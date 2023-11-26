namespace TBot.Core.UpdateEngine;

public class Coordinator
{
    private readonly Context _context;
    public string? GoToName { get; set; }
    
    public Status Status { get; private set; }

    public Coordinator(Context context)
    {
        _context = context;
    }
    
    public virtual Context ReturnCompleted()
    {
        Status = Status.Complete;
        return _context;
    }
    
    public virtual Context ReturnInterrupted()
    {
        Status = Status.Interrupt;
        return _context;
    }
    
    public virtual Context ReturnContinued()
    {
        Status = Status.Continue;
        return _context;
    }
    
    public virtual Context WithStatus(Status status)
    {
        Status = status;
        return _context;
    }

    public virtual Context GoTo(string name)
    {
        Status = Status.GoTo;
        GoToName = name;
        return _context;
    }
}

public enum Status
{
    Interrupt,
    Complete,
    Continue,
    GoTo
}