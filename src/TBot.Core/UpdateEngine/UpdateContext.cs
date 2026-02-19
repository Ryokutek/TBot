using TBot.Dto.Updates;

namespace TBot.Core.UpdateEngine;

public class UpdateContext
{
    public UpdateDto UpdateDto { get; }
    public long UserId { get;  }
    public long ChatId { get; }
    public long UpdateId { get;  }
    
    private UpdateContext(UpdateDto updateDto, long userId, long chatId, long updateId)
    {
        UpdateDto = updateDto;
        UserId = userId;
        ChatId = chatId;
        UpdateId = updateId;
    }

    public static UpdateContext Create(UpdateDto updateDto)
    {
        return new UpdateContext(
            updateDto,
            ExtractUserId(updateDto),
            ExtractChatId(updateDto),
            ExtractUpdateId(updateDto));
    }
    
    private static long ExtractUserId(UpdateDto update)
        => update.Message?.From?.Id
           ?? update.CallbackQuery?.From.Id
           ?? throw new InvalidOperationException("UserId not found.");
    
    private static long ExtractUpdateId(UpdateDto update) => update.UpdateId;

    private static long ExtractChatId(UpdateDto update)
        => update.Message?.Chat.Id
           ?? update.CallbackQuery?.Message?.Chat.Id
           ?? throw new InvalidOperationException("ChatId not found.");
}