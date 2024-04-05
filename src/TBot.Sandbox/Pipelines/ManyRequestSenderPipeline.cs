using TBot.Core.RequestOptions;
using TBot.Core.TBot;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.UpdateEngine;

namespace TBot.Sandbox.Pipelines;

public class ManyRequestSenderPipeline(ITBotClient botClient) : UpdatePipeline
{
    public override async Task<PipelineContext> ExecuteAsync(PipelineContext pipelineContext)
    {
        if (!pipelineContext.Update.IsMessage() || pipelineContext.Update.Message!.Text != "send")
            return await ExecuteNextAsync(pipelineContext);

        
        
        return await base.ExecuteAsync(pipelineContext);
    }
}