namespace TBot.ReplyKeyboard.Models;

public class RootReplyKeyboard
{
    private ReplyKeyboardModel MainReplyKeyboardModel { get; set; }
    
    private RootReplyKeyboard(ReplyKeyboardModel replyKeyboardModel)
    {
        MainReplyKeyboardModel = replyKeyboardModel;
    }

    public static RootReplyKeyboard Create(ReplyKeyboardModel replyKeyboardModel)
    {
        return new RootReplyKeyboard(replyKeyboardModel);
    }

    public ReplyKeyboardModel? GetKeyboard(string name)
    {
        return FirstOrDefaultKeyboard(name, MainReplyKeyboardModel);
    }
    
    public ReplyKeyboardModel? GetPreviousKeyboard(string name)
    {
        return PreviousOrDefaultPanel(name, MainReplyKeyboardModel);
    }
    
    private static ReplyKeyboardModel? PreviousOrDefaultPanel(string name, ReplyKeyboardModel replyKeyboardModel)
    {
        return replyKeyboardModel.Buttons.Where(button => button.IsReplyKeyboard)
            .Select(x => x.ReplyKeyboard)
            .Select(replyKeyboardModelInternal => replyKeyboardModelInternal!.Name == name
                ? replyKeyboardModel
                : PreviousOrDefaultPanel(name, replyKeyboardModelInternal))
            .FirstOrDefault();
    }
    
    private static ReplyKeyboardModel? FirstOrDefaultKeyboard(string name, ReplyKeyboardModel replyKeyboardModel)
    {
        return replyKeyboardModel.Name == name 
            ? replyKeyboardModel 
            : replyKeyboardModel.Buttons.Where(button => button.IsReplyKeyboard)
                .Select(x => x.ReplyKeyboard).Select(replyKeyboardModelInternal =>
                    FirstOrDefaultKeyboard(name, replyKeyboardModelInternal!)).FirstOrDefault();
    }
}