using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Invoices;

public partial class Invoices : ComponentBase
{
    [Parameter]
    public EventCallback<InvoiceVM> OnSelect { get; set; }

    #region Data Grid
    public List<InvoiceVM> _invoices { get; set; }
    private string _filterString = string.Empty;
    IQueryable<InvoiceVM>? FilteredItems => _invoices?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
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

    public async Task Refresh() => await _getRecords();

    private async Task HandleRowFocus(FluentDataGridRow<InvoiceVM> row)
    {
        SelectedRecord = row.Item as InvoiceVM;
        await OnSelect.InvokeAsync(SelectedRecord);
    }

    private async Task _getRecords()
    {
        var dtosInv = await DataProvider.Invoices.GetAll();
        _invoices = Mapper.Map<List<InvoiceVM>>(dtosInv);
    }

    private async Task _add()
    {
        SelectedRecord = new InvoiceVM()
        {
            Date = DateTime.Now,
        };
        StateHasChanged();
        await OnSelect.InvokeAsync(SelectedRecord);

        //DialogParameters parameters = new()
        //{
        //    Title = $"New Record",
        //    PrimaryActionEnabled = true,
        //    SecondaryActionEnabled = true,
        //    PrimaryAction = "Save",
        //    SecondaryAction = "Cancel",
        //    TrapFocus = true,
        //    Modal = true,
        //    PreventScroll = true,
        //    Width = "min(70%, 500px);"
        //};

        //IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(new InvoiceVM(), parameters);
        //DialogResult? result = await dialog.Result;

        //if (result.Data is not null)
        //{
        //    InvoiceVM vm = result.Data as InvoiceVM;
        //    var dto = Mapper.Map<InvoiceDto>(vm);
        //    await DataProvider.Invoices.Add(dto);
        //    await _getRecords();
        //}
    }

    //private async Task _edit(InvoiceVM record)
    //{
    //    DialogParameters parameters = new()
    //    {
    //        Title = $"Edit {record.Project?.Name: 'Record'}",
    //        PrimaryActionEnabled = true,
    //        SecondaryActionEnabled = true,
    //        PrimaryAction = "Save",
    //        SecondaryAction = "Cancel",
    //        TrapFocus = true,
    //        Modal = true,
    //        PreventScroll = true,
    //        Width = "min(70%, 500px);"
    //    };

    //    IDialogReference dialog = await DialogService.ShowDialogAsync<InvoiceDetailedDialog>(record, parameters);
    //    DialogResult? result = await dialog.Result;

    //    if (result.Data is not null)
    //    {
    //        InvoiceVM vm = result.Data as InvoiceVM;
    //        var dto = Mapper.Map<InvoiceDto>(vm);
    //        await DataProvider.Invoices.Update(dto);
    //        await _getRecords();
    //    }
    //}

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
            if (_invoices == null || _invoices.Count == 0)
                await _getRecords();

            StateHasChanged();
        }
    }
}
