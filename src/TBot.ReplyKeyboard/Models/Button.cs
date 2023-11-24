namespace TBot.ReplyKeyboard.Models;

public class Button
{
    public bool IsReplyKeyboard { get; set; } = false;
    public ReplyKeyboardModel? ReplyKeyboard { get; set; }
    
    public string Text { get; set; } = null!;

    public bool IsEnable { get; set; } = true;
    public bool IsBack { get; set; } = false;
    public int Index { get; set; }
    public int Line { get; set; }
}