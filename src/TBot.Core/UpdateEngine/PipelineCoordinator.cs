namespace TBot.Core.UpdateEngine;

public class PipelineCoordinator
{
    private readonly PipelineContext _pipelineContext;
    private string? GoToPipeline { get; set; }
    
    public PipelineStatus PipelineStatus { get; private set; }

    public PipelineCoordinator(PipelineContext pipelineContext)
    {
        _pipelineContext = pipelineContext;
    }
    
    public PipelineContext ReturnCompleted()
    {
        PipelineStatus = PipelineStatus.Complete;
        return _pipelineContext;
    }
    
    public PipelineContext ReturnInterrupted()
    {
        PipelineStatus = PipelineStatus.Interrupt;
        return _pipelineContext;
    }
    
    public PipelineContext WithStatus(PipelineStatus pipelineStatus)
    {
        PipelineStatus = pipelineStatus;
        return _pipelineContext;
    }

    public PipelineContext GoTo(string pipelineName)
    {
        PipelineStatus = PipelineStatus.GoTo;
        GoToPipeline = pipelineName;
        return _pipelineContext;
    }
}

public enum PipelineStatus
{
    Interrupt,
    Complete,
    Continue,
    GoTo
}