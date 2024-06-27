using System.Reflection;

namespace EmpiriaBMS.Models.Models;

public static class ObjectComparer
{
    public static bool AreEqualExcludeId<T>(this T obj1, T obj2) where T : class, IEntity
    {
        if (obj1 == null || obj2 == null)
        {
            return obj1 == obj2;
        }

        var type = typeof(T);

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                     .Where(prop => prop.Name != "Id"
                         && prop.PropertyType != typeof(DateTime)
                         && !_isExcludedCollectionType(prop.PropertyType));

        foreach (var property in properties)
        {
            var value1 = property.GetValue(obj1);
            var value2 = property.GetValue(obj2);

            if (value1 is IList<object> list1 && value2 is IList<object> list2)
            {
                if (!list1.SequenceEqual(list2))
                {
                    return false;
                }
            }
            else
            {
                if (!Equals(value1, value2))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool _isExcludedCollectionType(Type type)
    {
        if (type.IsGenericType)
        {
            var genericTypeDefinition = type.GetGenericTypeDefinition();
            return genericTypeDefinition == typeof(IList<>) ||
                   genericTypeDefinition == typeof(IEnumerable<>) ||
                   genericTypeDefinition == typeof(ICollection<>) ||
                   genericTypeDefinition == typeof(List<>);
        }

        return false;
    }
}
