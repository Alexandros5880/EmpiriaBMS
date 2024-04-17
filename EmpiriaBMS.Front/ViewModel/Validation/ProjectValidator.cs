using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Components.Base;
using EmpiriaBMS.Front.ViewModel.Validation.Base;
using EmpiriaBMS.Front.ViewModel.Validation.Contracts;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Kiota.Abstractions;
using System.Reflection;
using System.Text.RegularExpressions;
using static Microsoft.Fast.Components.FluentUI.Icons.Filled.Size16;

namespace EmpiriaBMS.Front.ViewModel.Validation;

public class ProjectValidator : BaseValidator<ProjectVM>
{
    #region SubCategory
    private bool _createSubCategoryValid = false;
    public bool CreateSubCategoryValid
    {
        get => _createSubCategoryValid;
        set
        {
            if (value == _createSubCategoryValid)
                return;
            _createSubCategoryValid = value;
            NotifyPropertyChanged(nameof(CreateSubCategoryValid));
        }
    }

    private string _createSubCategoryErr = null;
    public string CreateSubCategoryErr
    {
        get => _createSubCategoryErr;
        set
        {
            if (value == _createSubCategoryErr)
                return;
            _createSubCategoryErr = value;
            NotifyPropertyChanged(nameof(CreateSubCategoryErr));
        }
    }
    #endregion

    #region Name
    private bool _nameValid = false;
    public bool NameValid
    {
        get => _nameValid;
        set
        {
            if (value == _nameValid)
                return;
            _nameValid = value;
            NotifyPropertyChanged(nameof(NameValid));
        }
    }

    private string _nameErr = null;
    public string NameErr
    {
        get => _nameErr;
        set
        {
            if (value == _nameErr)
                return;
            _nameErr = value;
            NotifyPropertyChanged(nameof(NameErr));
        }
    }
    #endregion

    #region CategoryId
    private bool _categoryIdValid = false;
    public bool CategoryIdValid
    {
        get => _categoryIdValid;
        set
        {
            if (value == _categoryIdValid)
                return;
            _categoryIdValid = value;
            NotifyPropertyChanged(nameof(CategoryIdValid));
        }
    }

    private string _categoryIdErr = null;
    public string CategoryIdErr
    {
        get => _categoryIdErr;
        set
        {
            if (value == _categoryIdErr)
                return;
            _categoryIdErr = value;
            NotifyPropertyChanged(nameof(CategoryIdErr));
        }
    }
    #endregion

    public new bool ValidateProperty(ProjectVM obj, string propertyName, object fieldValue = null)
    {
        try
        {
            object value = fieldValue != null ? fieldValue : _getPropertyValue(obj, propertyName);

            switch (propertyName)
            {
                case "SubCategoryName":
                    CreateSubCategoryValid = !string.IsNullOrEmpty((string)value);
                    CreateSubCategoryErr = CreateSubCategoryValid ? null : "SubCategory name requared!";
                    return CreateSubCategoryValid;
                case nameof(ProjectVM.Name):
                    NameValid = !string.IsNullOrEmpty((string)value);
                    NameErr = NameValid ? null : "Name requared!";
                    return NameValid;
                case nameof(ProjectVM.CategoryId    ):
                    NameValid = !string.IsNullOrEmpty((string)value);
                    NameErr = NameValid ? null : "Category requared!";
                    return NameValid;
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

    public new bool Validate(ProjectVM obj)
    {
        try
        {
            ValidateProperty(obj, nameof(ProjectVM.CategoryId), obj.CategoryId);
            ValidateProperty(obj, nameof(ProjectVM.Name), obj.Name);
            ValidateProperty(obj, nameof(ProjectVM.CategoryId), obj.CategoryId);

            return CreateSubCategoryValid || NameValid;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error

            return false;
        }
    }
}
