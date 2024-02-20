using TBot.Core.RequestOptions;
using TBot.Core.TBot;
using TBot.Core.UpdateEngine;

namespace TBot.Sandbox.Pipelines;

public class GreetingPipeline(ILogger<GreetingPipeline> logger, ITBotClient botClient) : UpdatePipeline
{
    public override async Task<Context> ExecuteAsync(Context context)
    {
        logger.LogInformation("GreetingPipeline execute...");
        
        if (!context.Update.IsMessage())
            return await ExecuteNextAsync(context);

        await botClient.SendMessageAsync(
            new SendMessageOptions(context.CurrentRequest.FromChatId, $"Greeting! {context.Update.Message!.From!.FirstName}"));
        
        return await ExecuteNextAsync(context);
    }
}