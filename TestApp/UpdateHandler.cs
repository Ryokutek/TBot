using TBot.Core.RequestOptions;
using TBot.Core.TBot.Interfaces;
using TBot.Core.UpdateEngine;

namespace TestApp;

public class UpdateHandler(ITBotClient botClient) : IUpdateHandler
{
    public async Task ExecuteAsync(UpdateContext context)
    {
        await botClient.SendMessageAsync(new SendMessageOptions(
            context.UpdateDto.Message!.From!.Id, "Hello, World!"));
    }
}