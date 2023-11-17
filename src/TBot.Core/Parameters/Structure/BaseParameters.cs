using System.Reflection;
using Newtonsoft.Json;
using TBot.Core.HttpRequests.Models;

namespace TBot.Core.Parameters.Structure;

public class BaseParameters
{
    public IEnumerable<QueryParameter> ToParameters()
    {
        Type baseParameters = GetType();
        
        foreach (PropertyInfo property in baseParameters.GetProperties())
        {
            object[] attributes = property.GetCustomAttributes(false);
            object? value = property.GetValue(this);

            ParameterAttribute? parameterAttribute = null;
            foreach (object attributeObject in attributes)
            {
                if (attributeObject is not ParameterAttribute attribute) {
                    continue;
                }
                
                parameterAttribute = attribute;
                break;
            }

            if (parameterAttribute is null)
            {
                continue;
            }

            if (value is Enum @enum)
            {
                value = Enum.GetName(@enum.GetType(), @enum);
            }
            
            if (!IsDefaultValue(value))
            {
                yield return new QueryParameter(parameterAttribute.Name, parameterAttribute.IsJson ? JsonConvert.SerializeObject(value) : value);
            }
            else if(parameterAttribute.Required)
            {
                throw new Exception($"Required property not set on property: {property.Name}");
            }
        }
    }

    private static bool IsDefaultValue(object? value)
    {
        return value switch
        {
            null => true,
            ValueType => Activator.CreateInstance(value.GetType())?.Equals(value) ?? false,
            _ => false
        };
    }
}