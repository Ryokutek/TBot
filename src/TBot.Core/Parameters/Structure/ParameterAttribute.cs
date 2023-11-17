namespace TBot.Core.Parameters.Structure;

[AttributeUsage(AttributeTargets.Property)]
public class ParameterAttribute : Attribute
{
    public string Name { get; }
    public bool Required { get; set; } 
    public bool IsJson { get; set; }
        
    public ParameterAttribute(string name)
    {
        Name = name;
    }
}