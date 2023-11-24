namespace TBot.ReplyKeyboard.Models;

public class ReplyKeyboardModel
{
    public string Name { get; set; } = null!;
    public List<Button> Buttons { get; set; } = new ();
}