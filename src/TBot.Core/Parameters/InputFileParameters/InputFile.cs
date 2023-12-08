namespace TBot.Core.Parameters.InputFileParameters;

public abstract class InputFile
{
    public abstract string ContentMediaType { get; }
    protected internal abstract object Value { get; }
}