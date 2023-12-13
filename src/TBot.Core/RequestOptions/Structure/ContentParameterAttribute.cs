namespace TBot.Core.RequestOptions.Structure;

public class ContentParameterAttribute : Attribute
{
    public string Name { get; }
    public bool Required { get; set; }
        
    public ContentParameterAttribute(string name)
    {
        Name = name;
    }
}