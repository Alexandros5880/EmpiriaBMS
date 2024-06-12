using System.ComponentModel.DataAnnotations;

namespace System;

public static class GetValueFromEnumDisplayName
{
    public static T GetValueFromDisplayName<T>(this string displayName) where T : Enum
    {
        var type = typeof(T);
        if (!type.IsEnum)
        {
            throw new ArgumentException($"{type} is not an enum type");
        }

        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(DisplayAttribute)) as DisplayAttribute;

            if (attribute != null && attribute.Name == displayName)
            {
                return (T)field.GetValue(null);
            }
        }

        throw new ArgumentException($"No {type} with display name {displayName} found.");
    }
}
