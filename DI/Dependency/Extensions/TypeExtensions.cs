using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Reflection.Extensions;
using static System.Reflection.BindingFlags;

namespace DIFeatures.Dependency.Extensions
{
  internal static class TypeExtensions
  {
    public static IEnumerable<FieldInfo> FieldsWith<TAttribute>(this Type type) where TAttribute : Attribute
    {
      while (type != null)
      {
        foreach (var field in type.FieldsWith<TAttribute>(Instance | NonPublic))
          yield return field;

        type = type.BaseType;
      }
    }
    
    public static TypeDependencies Dependencies(this Type self) =>
      new TypeDependencies(self);
  }
}