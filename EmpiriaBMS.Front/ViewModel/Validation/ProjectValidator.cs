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

namespace EmpiriaBMS.Front.ViewModel.Validation;

public class ProjectValidator : BaseValidator<ProjectVM>
{
    #region Group
    private bool _createGroupValid = false;
    public bool CreateGroupValid
    {
        get => _createGroupValid;
        set
        {
            if (value == _createGroupValid)
                return;
            _createGroupValid = value;
            NotifyPropertyChanged(nameof(CreateGroupValid));
        }
    }

    private string _createGroupErr = null;
    public string CreateGroupErr {
        get => _createGroupErr;
        set
        {
            if (value == _createGroupErr)
                return;
            _createGroupErr = value;
            NotifyPropertyChanged(nameof(CreateGroupErr));
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

    #region GroupId
    private bool _groupIdValid = false;
    public bool GroupIdValid
    {
        get => _groupIdValid;
        set
        {
            if (value == _groupIdValid)
                return;
            _groupIdValid = value;
            NotifyPropertyChanged(nameof(GroupIdValid));
        }
    }

    private string _groudpIdErr = null;
    public string GroupIdErr
    {
        get => _groudpIdErr;
        set
        {
            if (value == _groudpIdErr)
                return;
            _groudpIdErr = value;
            NotifyPropertyChanged(nameof(GroupIdErr));
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
                case "GroupName":
                    CreateGroupValid = !string.IsNullOrEmpty((string)value);
                    CreateGroupErr = CreateGroupValid ? null : "Group name requared!";
                    return CreateGroupValid;
                case nameof(ProjectVM.GroupId):
                    GroupIdValid = Convert.ToInt32(value) != 0;
                    GroupIdErr = NameValid ? null : "Group requared!";
                    return GroupIdValid;
                case nameof(ProjectVM.Name):
                    NameValid = !string.IsNullOrEmpty((string)value);
                    NameErr = NameValid ? null : "Group name requared!";
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
}
