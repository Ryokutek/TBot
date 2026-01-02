namespace TBot.Core.RequestOptions.Structure;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParameterAttribute(string name) : Attribute
{
    public string Name { get; } = name;
    public bool Required { get; set; }
    public bool IsJson { get; set; }
}