﻿using System.Reflection;

namespace TBot.Core.RequestOptions.Structure;

public class Parameter<TAttribute> where TAttribute : class
{
    public TAttribute Attribute { get; set; } = null!;
    public PropertyInfo PropertyInfo { get; set; } = null!;
}