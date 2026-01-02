using TBot.Dto.Updates;

namespace TBot.Core.TBot.EnvironmentManagement;

public static class CurrentRequestMapper
{
    public static CurrentRequest ToSession(this UpdateDto update)
    {
        if (update.Message is not null)
        {
            return CurrentRequest.Create(Guid.NewGuid(), update.Message!.Chat.Id, update.Message!.From?.Id ?? 0);
        }

        if (update.CallbackQuery is not null)
        {
            return CurrentRequest.Create(Guid.NewGuid(), update.CallbackQuery!.Message!.Chat.Id, update.CallbackQuery!.From.Id);
        }

        return CurrentRequest.CreateEmpty();
    }
}