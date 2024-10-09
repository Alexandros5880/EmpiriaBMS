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


namespace EmpiriaBMS.Front.Components.Admin.Projects.Clients;

public partial class ClientDetailed
{
    [Parameter]
    public ClientVM Content { get; set; } = default!;

    [Parameter]
    public EventCallback OnCancel { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            Validate("Emails");

            await RefreshMap();

            StateHasChanged();
        }
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;


        ClientDto dto = _mapper.Map<ClientDto>(Content);

        dto.Emails = null;
        var emailsDtos = Mapping.Mapper.Map<List<EmailDto>>(_emails);

        // If Addres Then Save Address
        if (dto?.Address != null && !(await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
        {
            var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
            var address = await _dataProvider.Address.Add(addressDto);
            dto.AddressId = address.Id;
        }
        else if (dto?.Address != null && (await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
        {
            var address = await _dataProvider.Address.GetByPlaceId(dto.Address.PlaceId);
            dto.AddressId = address.Id;
        }

        if (Content.Id == 0)
        {
            var added = await _dataProvider.Clients.Add(dto);
            if (added != null)
            {
                _emails.ForEach(e => e.ClientId = added.Id);
                emailsDtos.ForEach(e => e.ClientId = added.Id);
                await _dataProvider.Clients.UpsertEmails(added.Id, emailsDtos);
            }
            added.Emails = _emails;
        }
        else
        {
            var updated = await _dataProvider.Clients.Update(dto);
            _emails.ForEach(e => e.ClientId = updated.Id);
            emailsDtos.ForEach(e => e.ClientId = updated.Id);
            await _dataProvider.Clients.UpsertEmails(updated.Id, emailsDtos);
            updated.Emails = _emails;
        }

        Content.Emails = _emails;
    }

    public async Task CancelAsync() => await OnCancel.InvokeAsync();

    private async Task _getRecords()
    {
        await _getEmails();
        await _getUsers();
    }

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
            await _dataProvider.Clients.RemoveUser(record.Id);

        var forDelete = _users.FirstOrDefault(x => x.Id == record.Id);
        _users.Remove(forDelete);

        await dialog.CloseAsync();
    }

    private async Task _getUsers()
    {
        if (Content == null || Content.Id == 0)
            return;

        var dtos = await _dataProvider.Clients.GetUsers(Content.Id);
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
            ClientId = Content.Id
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

    #region Emails Data Grid
    FluentDataGrid<Email> myGrid;
    private List<Email> _emails = new List<Email>();
    private string _filterString = string.Empty;
    IQueryable<Email> FilteredEmails => _emails?.AsQueryable().Where(x => x.Address.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState emailsPeginator = new PaginationState { ItemsPerPage = 5 };

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
                ClientId = Content.Id,
            });
        }

        var valid = Validate("Emails");
        if (valid)
            Content.Emails = _emails;
    }

    private async Task _getEmails()
    {
        if (Content == null || Content.Id == 0)
            return;

        var emails = await _dataProvider.Clients.GetEmails(Content.Id);
        _emails = emails.ToList();

        Content.Emails = emails;
    }

    private async Task _addEmail()
    {
        _emails.Add(new Email()
        {
            Address = string.Empty,
            ClientId = Content.Id
        });
        await myGrid.RefreshDataAsync();
    }

    private async Task _deleteEmail(Email email)
    {
        _emails.Remove(email);
        await myGrid.RefreshDataAsync();
    }
    #endregion

    #region Validation
    private bool validEmails = true;
    private bool validName = true;
    private bool validPhone = true;
    private bool validCompanyName = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validEmails = _emails?.Any() ?? false;
            validName = !string.IsNullOrEmpty(Content.Name);
            validPhone = !string.IsNullOrEmpty(Content.Phone) && _isValidPhoneNumber(Content.Phone);
            validCompanyName = !string.IsNullOrEmpty(Content.CompanyName);

            return validEmails && validName && validPhone && validCompanyName;
        }
        else
        {
            validEmails = true;
            validName = true;
            validPhone = true;
            validCompanyName = true;

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
                case "CompanyName":
                    validCompanyName = !string.IsNullOrEmpty(Content.CompanyName);
                    return validCompanyName;
                default:
                    return true;
            }

        }
    }

    private bool _isValidEmail(string email) => GeneralValidator.IsValidEmail(email);
    private bool _isValidPhoneNumber(string phone) => GeneralValidator.IsValidPhoneNumber(phone);
    #endregion

    #region Map Address
    private Map _map;

    public async Task RefreshMap()
    {
        if (Content.Id != 0 && Content.Address != null)
        {
            await _map.SetAddress(Content.Address);
        }
    }

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Content.Address = address;
    }
    #endregion
}