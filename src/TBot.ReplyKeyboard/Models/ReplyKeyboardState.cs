namespace TBot.ReplyKeyboard.Models;

public class ReplyKeyboardState
{
    public Guid SessionId { get; set; }
    public long ChatId { get; set; }
    public string CurrentReplyKeyboardName { get; set; } = null!;
}