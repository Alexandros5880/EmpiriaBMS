using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.General;
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
            await OnSave.InvokeAsync(_mapper.Map<ClientVM>(added));
        }
        else
        {
            var updated = await _dataProvider.Clients.Update(dto);
            _emails.ForEach(e => e.ClientId = updated.Id);
            emailsDtos.ForEach(e => e.ClientId = updated.Id);
            await _dataProvider.Clients.UpsertEmails(updated.Id, emailsDtos);
            updated.Emails = _emails;
            await OnSave.InvokeAsync(_mapper.Map<ClientVM>(updated));
        }

        Content.Emails = _emails;
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

    private async Task _getRecords()
    {
        var emails = await _dataProvider.Clients.GetEmails(Content.Id);
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
                ClientId = Content.Id,
            });
        }

        var valid = Validate("Emails");
        if (valid)
            Content.Emails = _emails;
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