namespace TBot.Core.Parameters.Structure;

[AttributeUsage(AttributeTargets.Property)]
public class QueryParameterAttribute : Attribute
{
    public string Name { get; }
    public bool Required { get; set; }
    public bool IsJson { get; set; }
        
    public QueryParameterAttribute(string name)
    {
        Name = name;
    }
}