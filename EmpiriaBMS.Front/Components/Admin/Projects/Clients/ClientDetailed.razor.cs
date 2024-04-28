using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;


namespace EmpiriaBMS.Front.Components.Admin.Projects.Clients;

public partial class ClientDetailed
{
    [Parameter]
    public ClientVM Content { get; set; } = default!;

    [Parameter]
    public EventCallback<ClientVM> OnSave { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            Validate("Emails");

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        Content.Emails = _emails;
        ClientDto dto = _mapper.Map<ClientDto>(Content);
        
        if (Content.Id == 0)
            await _dataProvider.Clients.Add(dto);
        else
            await _dataProvider.Clients.Update(dto);

        await OnSave.InvokeAsync(Content);
    }

    private async Task CancelAsync() => await OnCancel.InvokeAsync();

    #region Data Grid
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

    private async Task _getRecords()
    {
        var emails = await _dataProvider.Users.GetEmails(Content.Id);
        _emails = emails.ToList();
    }

    private void _onEmailAddressChange(string preEmailAddress, ChangeEventArgs e)
    {
        var newEmailAddress = e.Value?.ToString();
        var email = _emails.FirstOrDefault(r => r.Address.Equals(preEmailAddress));
        var index = _emails.IndexOf(email);
        _emails[index].Address = newEmailAddress;
        Validate("Emails");
    }

    private async Task _addEmail()
    {
        _emails.Add(new Email()
        {
            Address = string.Empty,
            UserId = Content.Id
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
    private bool validFirstName = true;
    private bool validLastName = true;
    private bool validPhone1 = true;
    private bool validPhone2 = true;
    private bool validPhone3 = true;
    private bool validProxyAddress = true;
    private bool validCompanyName = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validEmails = _emails?.Any() ?? false;
            validFirstName = !string.IsNullOrEmpty(Content.FirstName);
            validLastName = !string.IsNullOrEmpty(Content.LastName);
            validPhone1 = !string.IsNullOrEmpty(Content.Phone1) && _isValidPhoneNumber(Content.Phone1);
            validPhone2 = string.IsNullOrEmpty(Content.Phone2) || _isValidPhoneNumber(Content.Phone2);
            validPhone3 = string.IsNullOrEmpty(Content.Phone3) || _isValidPhoneNumber(Content.Phone3);
            validProxyAddress = _isValidEmail(Content.ProxyAddress);
            validCompanyName = !string.IsNullOrEmpty(Content.CompanyName);

            return validEmails && validFirstName && validLastName && validPhone1 && validPhone2 && validPhone3 && validProxyAddress && validCompanyName;
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
            validCompanyName = true;

            switch (fieldname)
            {
                case "Emails":
                    validEmails = Content.Emails?.Any() ?? false;
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
                case "CompanyName":
                    validCompanyName = !string.IsNullOrEmpty(Content.CompanyName);
                    return validCompanyName;
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