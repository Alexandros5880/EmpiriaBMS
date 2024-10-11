using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using EmpiriaBMS.Front.Components.Admin.Users;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

public partial class SubConstructorDetailed
{
    [Parameter]
    public SubConstructorVM Content { get; set; } = new SubConstructorVM()
    {
        Id = 0
    };

    [Parameter]
    public EventCallback<SubConstructorVM> OnSave { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    [Parameter]
    public string AcceptActionText { get; set; } = "Save";

    [Parameter]
    public string CancelActionText { get; set; } = "Cancel";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getEmails();
            await _getUsers();

            Validate("SubConstructors");

            StateHasChanged();
        }
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        SubConstructorDto dto = _mapper.Map<SubConstructorDto>(Content);

        dto.Emails = null;
        var emailsDtos = Mapping.Mapper.Map<List<EmailDto>>(_emails);

        if (Content.Id == 0)
        {
            var added = await _dataProvider.SubConstructors.Add(dto);
            if (added != null)
            {
                _emails.ForEach(e => e.SubConstructorId = added.Id);
                emailsDtos.ForEach(e => e.SubConstructorId = added.Id);
                await _dataProvider.SubConstructors.UpsertEmails(added.Id, emailsDtos);
                added.Emails = _emails;
                await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(added));
                Content = _mapper.Map<SubConstructorVM>(added);
            }
        }
        else
        {
            var updated = await _dataProvider.SubConstructors.Update(dto);
            if (updated != null)
            {
                _emails.ForEach(e => e.SubConstructorId = updated.Id);
                emailsDtos.ForEach(e => e.SubConstructorId = updated.Id);
                await _dataProvider.SubConstructors.UpsertEmails(updated.Id, emailsDtos);
                updated.Emails = _emails;
                await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(updated));
                Content = _mapper.Map<SubConstructorVM>(updated);
            }
        }
    }

    public async Task CancelAsync() => await OnCancel.InvokeAsync();

    #region Emails Data Grid
    FluentDataGrid<Email> myGrid;
    private List<Email> _emails = new List<Email>();
    private string _filterString = string.Empty;
    IQueryable<Email> FilteredEmails => _emails?.AsQueryable().Where(x => x.Address.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private void HandleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterString) || string.IsNullOrEmpty(_filterString))
        {
            _filterString = string.Empty;
        }
    }

    private async Task _getEmails()
    {
        var emails = await _dataProvider.SubConstructors.GetEmails(Content.Id);
        _emails = emails.ToList();
        Content.Emails = emails;
    }

    private void _onEmailAddressChange(string preEmailAddress, ChangeEventArgs e)
    {
        var newEmailAddress = e.Value?.ToString();
        var validRegex = _isValidEmail(newEmailAddress);
        if (!validRegex)
            return;

        var email = _emails.FirstOrDefault(r => r.Address.Equals(preEmailAddress));
        if (email != null)
        {
            var index = _emails.IndexOf(email);
            _emails[index].Address = newEmailAddress;
        }

        else
        {
            _emails.Add(new Email()
            {
                Address = newEmailAddress,
                SubConstructorId = Content.Id,
            });
        }

        Validate("Email");
    }

    private async Task _addEmail()
    {
        _emails.Add(new Email()
        {
            Address = string.Empty,
            SubConstructorId = Content.Id
        });
        await myGrid.RefreshDataAsync();
    }

    private async Task _deleteEmail(long emailId)
    {
        var email = _emails.FirstOrDefault(e => e.Id == emailId);
        _emails.Remove(email);
        await myGrid.RefreshDataAsync();
    }
    #endregion

    #region Users Data Grid
    IQueryable<UserVM> FilteredUsers => _users?.AsQueryable().Where(x => x.FullName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState _usersPagination = new PaginationState { ItemsPerPage = 5 };
    ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();
    private UserVM _selectedUser = new UserVM();
    private string _detailedUserTitle = "";
    private string _detailedUserAcceptButtonText = "";
    private UserDetailed _userDetailComp;
    private bool _addUserMode = false;

    private void HandleUsersFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterString) || string.IsNullOrEmpty(_filterString))
        {
            _filterString = string.Empty;
        }
    }

    private void HandleUsersRowFocus(FluentDataGridRow<UserVM> row)
    {
        _selectedUser = row.Item as UserVM;
    }

    private async Task _deleteUser(UserVM record)
    {
        var dialog = await _dialogService.ShowConfirmationAsync($"Are you sure you want to delete this user {record.FullName}?", "Yes", "No", "Deleting user...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
            await _dataProvider.SubConstructors.RemoveUser(record.Id);

        var forDelete = _users.FirstOrDefault(x => x.Id == record.Id);
        _users.Remove(forDelete);

        await dialog.CloseAsync();
    }

    private async Task _getUsers()
    {
        if (Content == null || Content.Id == 0)
            return;

        var dtos = await _dataProvider.SubConstructors.GetUsers(Content.Id);
        var vms = _mapper.Map<List<UserVM>>(dtos);

        _users.Clear();
        vms.ForEach(_users.Add);
    }

    private void _addUser()
    {
        _detailedUserTitle = "Add User";
        _detailedUserAcceptButtonText = "Add User";

        _selectedUser = new UserVM()
        {
            SubConstructorId = Content.Id
        };

        _addUserMode = true;
    }

    private void _editUser(UserVM record)
    {
        _detailedUserTitle = "Edit User";
        _detailedUserAcceptButtonText = "Edit User";

        _selectedUser = record;

        _addUserMode = true;
    }

    private void _onUserSave(UserVM updated)
    {
        var exists = _users.Any(u => u.Id == updated.Id);
        if (exists)
        {
            var old = _users.FirstOrDefault(u => u.Id == updated.Id);
            var index = _users.IndexOf(old);
            _users.Remove(old);
            _users.Insert(index, updated);
        }
        else
        {
            _users.Insert(0, updated);
        }

        _addUserMode = false;
    }

    private void _onUserCancel()
    {
        _addUserMode = false;
    }
    #endregion

    #region Validation
    private bool validEmails = true;
    private bool validName = true;
    private bool validPhone = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validEmails = _emails?.Any() ?? false;
            validName = !string.IsNullOrEmpty(Content.Name);
            validPhone = !string.IsNullOrEmpty(Content.Phone) && _isValidPhoneNumber(Content.Phone);

            return validEmails && validName && validPhone;
        }
        else
        {
            validEmails = true;
            validName = true;
            validPhone = true;

            switch (fieldname)
            {
                case "Emails":
                    validEmails = _emails?.Any() ?? false;
                    return validEmails;
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                case "Phone":
                    validPhone = !string.IsNullOrEmpty(Content.Phone) && _isValidPhoneNumber(Content.Phone);
                    return validPhone;
                default:
                    return true;
            }

        }
    }

    private bool _isValidEmail(string email) => GeneralValidator.IsValidEmail(email);
    private bool _isValidPhoneNumber(string phone) => GeneralValidator.IsValidPhoneNumber(phone);
    #endregion
}
