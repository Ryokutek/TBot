namespace TBot.Core.RequestOptions.Structure;

public class ContentParameterAttribute(string name) : Attribute
{
    public string Name { get; } = name;
    public bool Required { get; set; }
}