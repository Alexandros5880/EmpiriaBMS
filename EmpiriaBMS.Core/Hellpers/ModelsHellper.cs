using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Hellpers;
public static class ModelsHellper
{
    public static void SetValues<T>(T oldObject, T newObject)
    {
        PropertyInfo[] properties = oldObject.GetType().GetProperties();

        foreach (var property in properties)
        {
            // Get the corresponding property from the new object
            PropertyInfo newProperty = newObject.GetType().GetProperty(property.Name);

            // If property exists in both old and new objects and is writable, update it
            if (newProperty != null && newProperty.CanWrite)
            {
                object value = newProperty.GetValue(newObject);
                property.SetValue(oldObject, value);
            }
        }
    }

    public static bool IsChanged<T>(T original, T current)
    {
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            var originalValue = property.GetValue(original);
            var currentValue = property.GetValue(current);

            if (!Equals(originalValue, currentValue))
            {
                return true;
            }
        }

        return false;
    }

    public static bool ListsChanged<T>(IEnumerable<T> list1, IEnumerable<T> list2)
    {
        var originalList = list1.ToList();
        var modifiedList = list2.ToList();

        // If counts are different, lists have definitely changed
        if (originalList.Count != modifiedList.Count)
            return true;

        // Check if any elements are different
        for (int i = 0; i < originalList.Count; i++)
        {
            // You might need to implement Equals() method in your objects for proper comparison
            if (!originalList[i].Equals(modifiedList[i]))
                return true;
        }

        // Lists are identical
        return false;
    }

}
