using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class Users
{
    #region Data Grid
    private List<UserVM> _records = new List<UserVM>();
    private string _filterString = string.Empty;
    IQueryable<UserVM>? FilteredItems => _records?.AsQueryable().Where(x => x.FullName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private UserVM _selectedRecord = new UserVM();

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

    private void HandleRowFocus(FluentDataGridRow<UserVM> row)
    {
        _selectedRecord = row.Item as UserVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Users.GetAll();
        _records = Mapper.Map<List<UserVM>>(dtos);
    }

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New Record",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70vw, 800px)",
            Height = "min(95vh, 1400px)"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<UsersDetailedDialog>(new UserVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            UserVM vm = result.Data as UserVM;
            var emails = Mapping.Mapper.Map<List<EmailDto>>(vm.Emails);
            emails.ForEach(e => e.User = null);
            vm.Emails = null;
            var myRolesIds = vm.MyRolesIds;
            var dto = Mapper.Map<UserDto>(vm);
            var added = await DataProvider.Users.Add(dto);
            if (added != null)
            {
                if (myRolesIds != null)
                    await DataProvider.Users.UpdateRoles(added.Id, myRolesIds);
                emails.ForEach(e => e.UserId = added.Id);
                await DataProvider.Emails.AddRange(emails);
                await _getRecords();
            }
        }
    }

    private async Task _edit(UserVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.FullName}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70vw, 800px)",
            Height = "min(95vh, 1400px)"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<UsersDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            UserVM vm = result.Data as UserVM;
            var emails = Mapping.Mapper.Map<List<EmailDto>>(vm.Emails);
            emails.ForEach(e => e.User = null);
            vm.Emails = null;
            var myRolesIds = vm.MyRolesIds;
            var dto = Mapper.Map<UserDto>(vm);
            await DataProvider.Users.Update(dto);
            if (myRolesIds != null)
                await DataProvider.Users.UpdateRoles(dto.Id, myRolesIds);
            await DataProvider.Emails.RemoveAll(dto.Id);
            await DataProvider.Emails.AddRange(emails);
            await _getRecords();
        }
    }

    private async Task _delete(UserVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the user {record.FullName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Users.Delete(record.Id);
        }

        await dialog.CloseAsync();
        await _getRecords();
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            StateHasChanged();
        }
    }

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Users-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new UserExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }

    private InputFile fileInput;
    private async Task ImportFromCSV(InputFileChangeEventArgs e)
    {
        var file = e.File;
        var filePath = file.Name;
        var fileType = file.ContentType;
        if (fileType?.Equals("text/csv") ?? false)
        {
            try
            {
                Stream stream = file.OpenReadStream();
                List<UserExport> data = await Data.ImportData<UserExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<UserDto>(vm);
                        var added = await DataProvider.Users.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<UserVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Users import: {ex.Message}, \nInner: {ex.InnerException?.Message}");
                // TODO: log error
            }
        }
    }
    private async Task TriggerFileInput()
    {
        var element = fileInput.Element;
        await MicrosoftTeams.TriggerFileInputClick(element);
    }
    #endregion
}
