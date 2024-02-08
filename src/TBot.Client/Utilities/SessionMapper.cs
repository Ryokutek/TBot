using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;

namespace TBot.Client.Utilities;

public static class SessionMapper
{
    public static UserSession ToSession(this Update update)
    {
        if (update.IsMessage())
        {
            return UserSession.Create(Guid.NewGuid(), update.Message!.Chat.Id, update.Message!.From?.Id ?? 0);
        }

        if (update.IsCallbackQuery())
        {
            return UserSession.Create(Guid.NewGuid(), update.CallbackQuery!.Message!.Chat.Id, update.CallbackQuery!.From.Id);
        }

        return UserSession.CreateEmpty();
    }
}