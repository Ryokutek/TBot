namespace TBot.Client.Utilities;

public static class StringFormatter
{
    public static string Escape(this string originalString)
    {
        char[] specialChars = ['\\', '_', '*', '[', ']', '(', ')', '~', '`', '>', '<', '&', '#', '+', '-', '=', '|', '{', '}', '.', '!'];
        return string.Concat(originalString.Select(c => specialChars.Contains(c) ? "\\" + c : c.ToString()));
    }
}