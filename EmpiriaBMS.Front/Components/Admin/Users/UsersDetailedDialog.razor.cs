using AutoMapper;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using System.Text.RegularExpressions;
using static Microsoft.Fast.Components.FluentUI.Emojis.Objects.Color.Default;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class UsersDetailedDialog : IDialogContentComponent<UserVM>
{
    [Parameter]
    public UserVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

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
        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

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
    private bool validPhone2= true;
    private bool validPhone3 = true;
    private bool validProxyAddress = true;

    private bool Validate(string fieldname = null)
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