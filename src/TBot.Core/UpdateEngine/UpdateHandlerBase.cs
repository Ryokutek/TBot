using TBot.Core.UpdateEngine.Interfaces;
using TBot.Dto.Updates;

namespace TBot.Core.UpdateEngine;

public abstract class UpdateHandlerBase : IUpdateHandler
{
    protected UpdateDto UpdateDto { get; private set; } = null!;
    protected long UserId { get; private set; }
    protected long ChatId { get; private set; }
    protected long UpdateId { get; private set; }

    public async Task ExecuteAsync(UpdateContext context, CancellationToken cancellationToken = default)
    {
        UpdateDto = context.UpdateDto;
        UserId = context.UserId;
        ChatId = context.ChatId;
        UpdateId = context.UpdateId;

        await HandleAsync(cancellationToken);
    }

    protected abstract Task HandleAsync(CancellationToken cancellationToken);
}