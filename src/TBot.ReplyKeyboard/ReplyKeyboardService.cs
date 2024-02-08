using TBot.Core.RequestOptions;
using TBot.Core.Stores;
using TBot.Core.TBot;
using TBot.Core.TBot.EnvironmentManagement;
using TBot.Core.Telegram;
using TBot.Core.UpdateEngine;
using TBot.ReplyKeyboard.Models;
using KeyboardButton = TBot.Core.RequestOptions.Reply.MarkumParameters.Buttons.KeyboardButton;
using ReplyKeyboardMarkup = TBot.Core.RequestOptions.Reply.MarkumParameters.Keyboards.ReplyKeyboardMarkup;

namespace TBot.ReplyKeyboard;

public class ReplyKeyboardService : UpdatePipeline
{
    private readonly RootReplyKeyboard _rootReplyKeyboard;
    private readonly ITBotClient _tBotClient;
    private readonly ITBotStore? _itBotStore;

    private static string GetKey(string chatId) => $"TBot:ReplyKeyboard:{chatId}";
    
    public ReplyKeyboardService(
        ReplyKeyboardModel replyKeyboardModel, 
        ITBotClient tBotClient, 
        ITBotStore? itBotStore)
    {
        _rootReplyKeyboard = RootReplyKeyboard.Create(replyKeyboardModel);
        _tBotClient = tBotClient;
        _itBotStore = itBotStore;
    }

    public override async Task<Context> ExecuteAsync(Context context)
    {
        if (!context.Update.IsMessage()) {
            return await ExecuteNextAsync(context);
        }
        
        var key = GetKey(TBotEnvironment.CurrentUser!.ChatId.ToString());
        var message = context.Update.Message;
        
        var keyboardModel = _rootReplyKeyboard.GetKeyboard(message!.Text!);
        
        if (keyboardModel is null)
        {
            keyboardModel = await TryGetPreviousKeyboardAsync(key, message.Text!);
            if (keyboardModel is null) {
                return await ExecuteNextAsync(context);
            }
        }

        await SendKeyboardAsync(message.From!.Id, keyboardModel!);
        await SaveReplyKeyboardStateAsync(key, keyboardModel!.Name);
        return await ExecuteNextAsync(context);
    }

    private async Task<ReplyKeyboardModel?> TryGetPreviousKeyboardAsync(string key, string messageText)
    {
        if (_itBotStore is null) {
            return default;
        }
        
        var replyKeyboardContext = await _itBotStore
            .GetAsync<ReplyKeyboardState>(key);

        if (replyKeyboardContext is null) {
            return default;
        }
                
        var keyboardModel = _rootReplyKeyboard.GetKeyboard(replyKeyboardContext.CurrentReplyKeyboardName);
        var button = keyboardModel?.Buttons.FirstOrDefault(x => x.Text == messageText && x.IsBack);
        
        if (button is null || keyboardModel is null) {
            return default;
        }
                
        return _rootReplyKeyboard.GetPreviousKeyboard(keyboardModel.Name);
    }
    
    private async Task SaveReplyKeyboardStateAsync(string key, string currentReplyName)
    {
        if (_itBotStore is null) {
            return;
        }
        
        if (await _itBotStore.ContainsAsync(key))
        {
            await _itBotStore.RemoveAsync(key);
        }
        
        _itBotStore?.SetAsync(key, new ReplyKeyboardState
        {
            SessionId = TBotEnvironment.CurrentUser?.Id ?? Guid.Empty,
            ChatId = TBotEnvironment.CurrentUser?.ChatId ?? default,
            CurrentReplyKeyboardName = currentReplyName
        });
    }
    
    private async Task SendKeyboardAsync(ChatIdentifier chatIdentifier, ReplyKeyboardModel keyboardModel)
    {
        var replyKeyboard = BuildReplyKeyboard(keyboardModel);
        await _tBotClient.SendMessageAsync(new SendMessageOptions(chatIdentifier, keyboardModel.Name)
        {
            ReplyMarkup = replyKeyboard
        });
    }

    private static ReplyKeyboardMarkup BuildReplyKeyboard(ReplyKeyboardModel keyboardModel)
    {
        var maxLine = keyboardModel.Buttons.Max(x=>x.Line) + 1;
        var keyboard = new ReplyKeyboardMarkup { OneTimeKeyboard = true, ResizeKeyboard = true };

        for (int i = 0; i < maxLine; i++)
        {
            bool isMenuButtonAdded = false;
            var maxIndex = keyboardModel.Buttons.Where(x=>x.Line == i).Max(x=>x.Index) + 1;
            for (int j = 0; j < maxIndex; j++)
            {
                var i1 = i;
                var j1 = j;
                
                var menuButtons = 
                    keyboardModel.Buttons.Where(x => x.Line == i1 && x.Index == j1);

                foreach (var menuButton in menuButtons)
                {
                    if (!menuButton.IsEnable)
                    {
                        continue;
                    }
                    
                    isMenuButtonAdded = true;
                    keyboard.Add(new KeyboardButton { Text = menuButton.Text });
                }
            }

            if (i + 1 != maxLine && isMenuButtonAdded)
            {
                keyboard.AddNextLine();
            }
        }

        return keyboard;
    }
}