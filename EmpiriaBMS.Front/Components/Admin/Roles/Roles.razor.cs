using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Roles;

public partial class Roles
{
    #region Data Grid
    private List<RoleVM> _records = new List<RoleVM>();
    private string _filterString = string.Empty;
    IQueryable<RoleVM> FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private RoleVM _selectedRecord = new RoleVM();

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

    private void HandleRowFocus(FluentDataGridRow<RoleVM> row)
    {
        _selectedRecord = row.Item as RoleVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Roles.GetAll();
        _records = Mapper.Map<List<RoleVM>>(dtos);
    }

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New record...",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<RolesDetailedDialog>(new RoleVM() { IsEditable = true }, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            RoleVM vm = result.Data as RoleVM;
            var dto = Mapper.Map<RoleDto>(vm);
            var role = await DataProvider.Roles.Add(dto);

            if (role == null)
                return; // Role Exists

            await DataProvider.Roles.UpdatePermissions(role.Id, vm.RolesPermissions.Select(rp => rp.PermissionId));

            var r = role;

            await _getRecords();
        }
    }

    private async Task _edit(RoleVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            Height = "88vh;",
            PreventScroll = true
        };

        var prevObj = record.Clone() as RoleVM;
        var prevRolesPerm = await DataProvider.Roles.GetMyPermissions(prevObj.Id);
        var prevPermissionsIds = prevRolesPerm.Select(rp => rp.Id);

        IDialogReference dialog = await DialogService.ShowDialogAsync<RolesDetailedDialog>(record, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            RoleVM vm = result.Data as RoleVM;

            var permissionsIds = vm.RolesPermissions.Select(rp => rp.PermissionId).ToList();
            vm.RolesPermissions = null;
            prevObj.RolesPermissions = null;

            var changed = ModelsHellper.IsChanged<RoleVM>(prevObj, vm);

            if (changed)
            {
                var dto = Mapper.Map<RoleDto>(vm);
                var updated = await DataProvider.Roles.Update(dto);
                if (updated == null)
                    return; // Role Exists
            }

            var permissionsChanged = ModelsHellper.ListsChanged<int>(prevPermissionsIds, permissionsIds);
            if (permissionsChanged)
                await DataProvider.Roles.UpdatePermissions(vm.Id, permissionsIds);

            if (changed || permissionsChanged)
                await _getRecords();
        }
    }

    private async Task _delete(RoleVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the role {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Roles.Delete(record.Id);
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
        var fileName = $"Roles-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new RoleExport(c)).ToList();
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
                List<RoleExport> data = await Data.ImportDataFromCsv<RoleExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<RoleDto>(vm);
                        var added = await DataProvider.Roles.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<RoleVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Roles.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
