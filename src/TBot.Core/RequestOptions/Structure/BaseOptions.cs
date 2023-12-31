﻿using Newtonsoft.Json;
using TBot.Core.HttpRequests.Models;
using TBot.Core.RequestOptions.Inputs;

namespace TBot.Core.RequestOptions.Structure;

public class BaseOptions
{
    public virtual IEnumerable<QueryParameter> ToParameters()
    {
        foreach (var parameter in GetParameters<QueryParameterAttribute>())
        {
            var value = parameter.PropertyInfo.GetValue(this);
            
            if (value is Enum @enum)
                value = Enum.GetName(@enum.GetType(), @enum);
            
            if (!IsDefaultValue(value)) {
                yield return new QueryParameter(parameter.Attribute.Name, 
                    parameter.Attribute.IsJson ? JsonConvert.SerializeObject(value) : value);
            }
            else if(parameter.Attribute.Required) {
                throw new Exception($"Required property not set on property: {parameter.PropertyInfo.Name}");
            }
        }
    }
    
    public virtual IEnumerable<Content> GetContents()
    {
        foreach (var parameter in GetParameters<ContentParameterAttribute>())
        {
            var value = parameter.PropertyInfo.GetValue(this);
            if (!IsDefaultValue(value)) {

                if (value is InputFile inputFile) {
                    yield return new Content { Name = parameter.Attribute.Name, Value = inputFile.Value, MediaType = inputFile.ContentMediaType };
                }
            }
            else if(parameter.Attribute.Required) {
                throw new Exception($"Required property not set on property: {parameter.PropertyInfo.Name}");
            }
        }
    }

    protected IEnumerable<Parameter<T>> GetParameters<T>() where T : Attribute
    {
        var options = GetType();
        foreach (var property in options.GetProperties())
        {
            var attributes = property.GetCustomAttributes(false);
            var optionAttribute = default(T);
            
            foreach (var attributeObject in attributes)
            {
                if (attributeObject is not T attribute) {
                    continue;
                }
                
                optionAttribute = attribute;
                break;
            }

            if (optionAttribute is null)
                continue;

            yield return new Parameter<T>
            {
                Attribute = optionAttribute,
                PropertyInfo = property
            };
        }
    }
    
    protected virtual bool IsDefaultValue(object? value)
    {
        return value switch
        {
            null => true,
            ValueType => Activator.CreateInstance(value.GetType())?.Equals(value) ?? false,
            _ => false
        };
    }
}