using TBot.Core.RequestOptions;
using TBot.Core.TBot.Interfaces;
using TBot.Core.UpdateEngine;

namespace TestApp;

public class WelcomeHandler(ITBotClient botClient) : UpdateHandlerBase
{
    protected override async Task HandleAsync(CancellationToken cancellationToken)
    {
        await botClient.SendMessageAsync(new SendMessageOptions(
            UpdateDto.Message!.From!.Id, "Hello, World!"));
    }
}