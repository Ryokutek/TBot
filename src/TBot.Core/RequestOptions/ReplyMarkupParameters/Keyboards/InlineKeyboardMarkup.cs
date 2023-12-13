using Newtonsoft.Json;
using TBot.Core.RequestOptions.ReplyMarkupParameters.Buttons;

namespace TBot.Core.RequestOptions.ReplyMarkupParameters.Keyboards;

public class InlineKeyboardMarkup : Keyboard<InlineKeyboardButton>
{
    [JsonProperty("inline_keyboard", Required = Required.Always)]
    protected override List<List<InlineKeyboardButton>> Buttons { get; set; } = new ();
}