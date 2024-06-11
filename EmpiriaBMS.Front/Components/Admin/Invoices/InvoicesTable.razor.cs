using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Invoices;

public partial class InvoicesTable
{
    [Parameter]
    public bool DisplayAddButton { get; set; } = true;

    [Parameter]
    public ProjectVM Project { get; set; } = null;

    [Parameter]
    public EventCallback<InvoiceVM> OnSelect { get; set; }

    #region Data Grid
    [Parameter]
    public List<InvoiceVM> Source { get; set; }

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    private string _filterString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => Source?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    [Parameter]
    public InvoiceVM SelectedRecord { get; set; } = new InvoiceVM();

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

    private async Task HandleRowFocus(FluentDataGridRow<InvoiceVM> row)
    {
        SelectedRecord = row.Item as InvoiceVM;
        await OnSelect.InvokeAsync(SelectedRecord);
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Invoices.GetAllByProject(projectId: Project != null ? Project.Id : 0);
        Source = Mapper.Map<List<InvoiceVM>>(dtos);
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

        IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(new InvoiceVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            InvoiceVM vm = result.Data as InvoiceVM;
            var dto = Mapper.Map<InvoiceDto>(vm);
            await DataProvider.Invoices.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(InvoiceVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Project?.Name: 'Record'}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 500px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            InvoiceVM vm = result.Data as InvoiceVM;
            var dto = Mapper.Map<InvoiceDto>(vm);
            await DataProvider.Invoices.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(InvoiceVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete invoice type{record.TypeName} of project {record.ProjectName}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Invoices.Delete(record.Id);
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
            if (Source == null || Source.Count == 0)
                await _getRecords();

            StateHasChanged();
        }
    }

    #region Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Invoices-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new InvoiceExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
