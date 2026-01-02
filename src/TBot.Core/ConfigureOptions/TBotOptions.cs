using System.Text.RegularExpressions;

namespace TBot.Core.ConfigureOptions;

// ReSharper disable once InconsistentNaming
public partial class TBotOptions
{
    public const string OptionsName = "TBotOptions";
    
    [GeneratedRegex("^[0-9]{8,10}:[a-zA-Z0-9_-]{35}$", RegexOptions.Compiled)]
    private static partial Regex BotTokenValidationRegex();

    public string Token
    {
        get;
        init
        {
            field = value;
            Validate(field);
        }
    } = null!;

    public string UpdatePath { get; set; } = null!;
    public UpdateOptions UpdateOptions { get; set; } = new ();
    public RedisOptions? RedisOption { get; set; }

    private static void Validate(string token)
    {
        if (!string.IsNullOrEmpty(token)) {
            if (BotTokenValidationRegex().Count(token) != 0) {
                return;
            }
        }
        
        throw new ArgumentException("Bot token cannot be empty");
    }
}