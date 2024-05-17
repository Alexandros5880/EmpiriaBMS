using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Validation.Contracts;
using System.Reflection;
using static Microsoft.Fast.Components.FluentUI.Icons.Filled.Size16;

namespace EmpiriaBMS.Front.ViewModel.Validation.Base;

public class BaseValidator<T> : BNotifyPropertyChanged, IValidator<T>
{
    public bool ValidateProperty(T obj, string propertyName, object fieldValue = null)
    {
        try
        {
            Type propertyType = _getPropertyType(obj, propertyName);
            object value = fieldValue != null ? fieldValue : _getPropertyValue(obj, propertyName);

            switch (Type.GetTypeCode(propertyType))
            {
                case TypeCode.Boolean:
                    return true;
                case TypeCode.Byte:
                    return true;
                case TypeCode.Char:
                    return true;
                case TypeCode.DateTime:
                    return true;
                case TypeCode.Decimal:
                    return true;
                case TypeCode.Double:
                    return true;
                case TypeCode.Int16:
                    return true;
                case TypeCode.Int32:
                    return true;
                case TypeCode.Int64:
                    return true;
                case TypeCode.Object:
                    return true;
                case TypeCode.SByte:
                    return true;
                case TypeCode.Single:
                    return true;
                case TypeCode.String:
                    return true;
                case TypeCode.UInt16:
                    return true;
                case TypeCode.UInt32:
                    return true;
                case TypeCode.UInt64:
                    return true;
                default:
                    return true;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return false;
        }
    }

    public bool Validate(T obj)
    {
        return true;
    }

    protected object _getPropertyValue(object obj, string propertyName)
    {
        Type type = obj.GetType();
        var property = type.GetProperty(propertyName);
        if (property != null)
        {
            return property.GetValue(obj);
        }
        else
        {
            throw new ArgumentException($"Property '{propertyName}' not found in type '{type.FullName}'.");
        }
    }

    protected Type _getPropertyType(object obj, string propertyName)
    {
        Type type = obj.GetType();
        var property = type.GetProperty(propertyName);
        if (property != null)
        {
            return property.PropertyType;
        }
        else
        {
            throw new ArgumentException($"Property '{propertyName}' not found in type '{type.FullName}'.");
        }
    }

    public void Reset() { }
}
