using TBot.Core.RequestOptions.ReplyMarkupParameters.Buttons;

namespace TBot.Core.RequestOptions.ReplyMarkupParameters.Keyboards;

public abstract class Keyboard<TButton> : ReplyMarkup where TButton : Button
{
    protected abstract List<List<TButton>> Buttons { get; set; }
    
    private int _line;

    public Keyboard<TButton> Add(TButton button)
    {
        if (!Buttons.Any())
        {
            Buttons.Add(new List<TButton>());
        }
        
        Buttons[_line].Add(button);
        return this;
    }

    public Keyboard<TButton> AddNextLine()
    {
        _line++;
        Buttons.Add(new List<TButton>());
        return this;
    }
}