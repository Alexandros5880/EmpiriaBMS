using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks;

public partial class SupportiveWorks
{
    #region Data Grid
    private List<OtherVM> _records = new List<OtherVM>();
    private string _filterString = string.Empty;
    IQueryable<OtherVM>? FilteredItems => _records?.AsQueryable().Where(x => x.TypeName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private OtherVM _selectedRecord = new OtherVM();

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

    private void HandleRowFocus(FluentDataGridRow<OtherVM> row)
    {
        _selectedRecord = row.Item as OtherVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Others.GetAll();
        _records = Mapper.Map<List<OtherVM>>(dtos);
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
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<SupportiveWorkDetailedDialog>(new OtherVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OtherVM vm = result.Data as OtherVM;
            var dto = Mapper.Map<OtherDto>(vm);
            await DataProvider.Others.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(OtherVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit DT-[{record.DisciplineTypeName}] T-[{record.TypeName}]",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<SupportiveWorkDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            OtherVM vm = result.Data as OtherVM;
            var dto = Mapper.Map<OtherDto>(vm);
            await DataProvider.Others.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(OtherVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the supportive work of type {record.TypeName} of discipline {record.DisciplineTypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Others.Delete(record.Id);
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
}
