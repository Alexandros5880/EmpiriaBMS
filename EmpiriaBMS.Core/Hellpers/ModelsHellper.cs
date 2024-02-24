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
}
