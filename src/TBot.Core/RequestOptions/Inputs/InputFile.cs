namespace TBot.Core.RequestOptions.Inputs;

public abstract class InputFile
{
    public abstract string ContentMediaType { get; }
    protected internal abstract object Value { get; }
    
    public static implicit operator InputFile(Stream stream)
    {
        return new StreamFile { Stream = stream };
    }
    
    public static implicit operator InputFile(string value)
    {
        return new StringIdentifierFile { StringIdentifier = value };
    }
}