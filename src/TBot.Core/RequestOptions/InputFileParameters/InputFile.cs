namespace TBot.Core.RequestOptions.InputFileParameters;

public abstract class InputFile
{
    public abstract string ContentMediaType { get; }
    protected internal abstract object Value { get; }
    
    public static implicit operator InputFile(Stream stream)
    {
        return new VideoFile { Stream = stream };
    }
    
    public static implicit operator InputFile(string value)
    {
        return new StringIdentifierFile { StringIdentifier = value };
    }
}