namespace EmpiriaBMS.Front.ViewModel.Validation.Contracts;

public interface IValidator<T>
{
    bool ValidateProperty(T obj, string propertyName, object fieldValue = null);
}
