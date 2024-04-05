using System.Text.RegularExpressions;
using TBot.Core.RequestOptions;
using TBot.Core.TBot;
using TBot.Core.UpdateEngine;

namespace TBot.Sandbox.Pipelines;

public class GreetingPipeline(ILogger<GreetingPipeline> logger, ITBotClient botClient) : UpdatePipeline
{
    public override async Task<PipelineContext> ExecuteAsync(PipelineContext pipelineContext)
    {
        logger.LogInformation("GreetingPipeline execute...");
        
        if (!pipelineContext.Update.IsMessage())
            return await ExecuteNextAsync(pipelineContext);

        await botClient.SendMessageAsync(
            new SendMessageOptions(pipelineContext.CurrentRequest.FromChatId, Escape("Greeting! \\ Nikita loh........")));
        
        return await ExecuteNextAsync(pipelineContext);
    }
    
    public static string Escape(string originalString)
    {
        char[] specialChars = ['\\', '_', '*', '[', ']', '(', ')', '~', '`', '>', '<', '&', '#', '+', '-', '=', '|', '{', '}', '.', '!'];
        return string.Concat(originalString.Select(c => specialChars.Contains(c) ? "\\" + c : c.ToString()));
    }
}