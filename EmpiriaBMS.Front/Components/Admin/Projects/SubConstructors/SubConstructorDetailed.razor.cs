using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

public partial class SubConstructorDetailed
{
    [Parameter]
    public SubConstructorVM Content { get; set; } = default!;

    [Parameter]
    public EventCallback<SubConstructorVM> OnSave { get; set; }

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
            await _getEmails();

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
            }
            added.Emails = _emails;
            await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(added));
        }
        else
        {
            var updated = await _dataProvider.SubConstructors.Update(dto);
            _emails.ForEach(e => e.SubConstructorId = updated.Id);
            emailsDtos.ForEach(e => e.SubConstructorId = updated.Id);
            await _dataProvider.SubConstructors.UpsertEmails(updated.Id, emailsDtos);
            updated.Emails = _emails;
            await OnSave.InvokeAsync(_mapper.Map<SubConstructorVM>(updated));
        }
    }

    public async Task CancelAsync() => await OnCancel.InvokeAsync();

    #region SubConstructors Data Grid
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

        Validate("SubConstructors");
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

    private async Task _deleteEmail(int emailId)
    {
        var email = _emails.FirstOrDefault(e => e.Id == emailId);
        _emails.Remove(email);
        await myGrid.RefreshDataAsync();
    }
    #endregion

    #region Validation
    private bool validSubConstructors = true;
    private bool validName = true;
    private bool validPhone = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validSubConstructors = _emails?.Any() ?? false;
            validName = !string.IsNullOrEmpty(Content.Name);
            validPhone = !string.IsNullOrEmpty(Content.Phone) && _isValidPhoneNumber(Content.Phone);

            return validSubConstructors && validName && validPhone;
        }
        else
        {
            validSubConstructors = true;
            validName = true;
            validPhone = true;

            switch (fieldname)
            {
                case "SubConstructors":
                    validSubConstructors = _emails?.Any() ?? false;
                    return validSubConstructors;
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
