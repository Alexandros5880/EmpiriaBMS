using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class UserDetailed
{
    [Parameter]
    public UserVM Content { get; set; } = default!;

    [Parameter]
    public string Title { get; set; } = null;

    [Parameter]
    public string Height { get; set; } = null;

    [Parameter]
    public bool Vertical { get; set; } = false;

    [Parameter]
    public EventCallback<UserVM> OnSave { get; set; } = default!;

    [Parameter]
    public EventCallback OnCancel { get; set; } = default!;

    private FluentTextField _firstNameField;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            Validate("Emails");

            _firstNameField.FocusAsync();

            StateHasChanged();
        }
    }

    private async Task _getRecords()
    {
        await _getEmails();
        await _getRoles();
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        Content.PasswordHash = Content.Password != null ? PasswordHasher.HashPassword(Content.Password) : null;
        Content.Emails = Emails;
        Content.MyRolesIds = Roles.Where(r => r.IsSelected).Select(r => r.Id).ToList();
        await OnSave.InvokeAsync(Content);
    }

    private async Task CancelAsync()
    {
        await OnCancel.InvokeAsync();
    }

    #region Data Grid Roles
    public List<RoleVM> Roles = new List<RoleVM>();
    private string _filterRoleString = string.Empty;
    IQueryable<RoleVM> FilteredRoles => Roles?.AsQueryable().Where(x => x.Name.Contains(_filterRoleString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState paginationRoles = new PaginationState { ItemsPerPage = 5 };

    private void HandleRoleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterRoleString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterRoleString) || string.IsNullOrEmpty(_filterRoleString))
        {
            _filterRoleString = string.Empty;
        }
    }

    private async Task _getRoles()
    {
        var allRoles = await _dataProvider.Roles.GetAll();

        var allRolesVms = _mapper.Map<List<RoleVM>>(allRoles);

        var myRoleIds = (await _dataProvider.Users.GetRoles(Content.Id)).Select(p => p.Id);

        var roles = new HashSet<RoleVM>();
        allRolesVms.ForEach(p =>
        {
            p.IsSelected = myRoleIds.Contains(p.Id);
            roles.Add(p);
        });

        Roles = roles.OrderByDescending(p => p.IsSelected).ToList();
    }

    private void _onRoleSelectionChange(int roleId, bool val)
    {
        var role = Roles.FirstOrDefault(r => r.Id == roleId);
        var index = Roles.IndexOf(role);
        Roles[index].IsSelected = val;
    }
    #endregion

    #region Data Grid Emails
    FluentDataGrid<Email> myEmailsGrid;
    public List<Email> Emails = new List<Email>();
    private string _filterEmailString = string.Empty;
    IQueryable<Email> FilteredEmails => Emails?.AsQueryable().Where(x => x.Address.Contains(_filterEmailString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState paginationEmails = new PaginationState { ItemsPerPage = 5 };

    private void HandleEmailsFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterEmailString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterEmailString) || string.IsNullOrEmpty(_filterEmailString))
        {
            _filterEmailString = string.Empty;
        }
    }

    private async Task _getEmails()
    {
        var emails = await _dataProvider.Users.GetEmails(Content.Id);
        Emails = emails.ToList();
        Content.Emails = emails;
    }

    private void _onEmailAddressChange(string preEmailAddress, ChangeEventArgs e)
    {
        var newEmailAddress = e.Value?.ToString();
        var validRegex = _isValidEmail(newEmailAddress);
        if (!validRegex)
            return;

        var email = Emails.FirstOrDefault(r => r.Address.Equals(preEmailAddress));
        if (email != null)
        {
            var index = Emails.IndexOf(email);
            Emails[index].Address = newEmailAddress;
        }

        else
        {
            Emails.Add(new Email()
            {
                Address = newEmailAddress,
                UserId = Content.Id,
            });
        }

        var valid = Validate("Emails");
        if (valid)
            Content.Emails = Emails;
    }

    private async Task _addEmail()
    {
        Emails.Add(new Email()
        {
            Address = string.Empty,
            UserId = Content.Id
        });
        await myEmailsGrid.RefreshDataAsync();
    }

    private async Task _deleteEmail(Email email)
    {
        Emails.Remove(email);
        await myEmailsGrid.RefreshDataAsync();
    }
    #endregion

    #region Validation
    private bool validEmails = true;
    private bool validFirstName = true;
    private bool validLastName = true;
    private bool validPhone1 = true;
    private bool validPhone2 = true;
    private bool validPhone3 = true;
    private bool validProxyAddress = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validEmails = Emails?.Any() ?? false;
            validFirstName = !string.IsNullOrEmpty(Content.FirstName);
            validLastName = !string.IsNullOrEmpty(Content.LastName);
            validPhone1 = !string.IsNullOrEmpty(Content.Phone1) && _isValidPhoneNumber(Content.Phone1);
            validPhone2 = string.IsNullOrEmpty(Content.Phone2) || _isValidPhoneNumber(Content.Phone2);
            validPhone3 = string.IsNullOrEmpty(Content.Phone3) || _isValidPhoneNumber(Content.Phone3);
            validProxyAddress = _isValidEmail(Content.ProxyAddress);

            return validEmails && validFirstName && validLastName && validPhone1 && validPhone2 && validPhone3 && validProxyAddress;
        }
        else
        {
            //validEmails = true;
            validFirstName = true;
            validLastName = true;
            validPhone1 = true;
            validPhone2 = true;
            validPhone3 = true;
            validProxyAddress = true;

            switch (fieldname)
            {
                case "Emails":
                    validEmails = Emails?.Any() ?? false;
                    return validEmails;
                case "FirstName":
                    validFirstName = !string.IsNullOrEmpty(Content.FirstName);
                    return validFirstName;
                case "LastName":
                    validLastName = !string.IsNullOrEmpty(Content.LastName);
                    return validLastName;
                case "Phone1":
                    validPhone1 = !string.IsNullOrEmpty(Content.Phone1) && _isValidPhoneNumber(Content.Phone1);
                    return validPhone1;
                case "Phone2":
                    validPhone2 = string.IsNullOrEmpty(Content.Phone2) && _isValidPhoneNumber(Content.Phone2);
                    return validPhone2;
                case "Phone3":
                    validPhone3 = string.IsNullOrEmpty(Content.Phone3) && _isValidPhoneNumber(Content.Phone3);
                    return validPhone3;
                case "ProxyAddress":
                    validProxyAddress = _isValidEmail(Content.ProxyAddress);
                    return validProxyAddress;
                default:
                    return true;
            }

        }
    }

    private void _onProxyAddressChange(ChangeEventArgs e)
    {
        Content.ProxyAddress = e.Value?.ToString();
        Validate("ProxyAddress");
    }

    private bool _isValidEmail(string email) => GeneralValidator.IsValidEmail(email);
    private bool _isValidPhoneNumber(string phone) => GeneralValidator.IsValidPhoneNumber(phone);
    #endregion
}
