using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects;

public partial class Projects
{
    #region Data Grid
    private List<ProjectVM> _records = new List<ProjectVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    [Parameter]
    public ProjectVM SelectedRecord { get; set; } = new ProjectVM();

    [Parameter]
    public EventCallback<ProjectVM> OnSelect { get; set; }

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

    private async Task HandleRowFocus(FluentDataGridRow<ProjectVM> row)
    {
        SelectedRecord = row.Item as ProjectVM;
        await OnSelect.InvokeAsync(SelectedRecord);
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Projects.GetAll();
        _records = Mapper.Map<List<ProjectVM>>(dtos);
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
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(new ProjectVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);


            // Save Project
            await DataProvider.Projects.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(ProjectVM record)
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
            PreventScroll = true,
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ProjectDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ProjectVM vm = result.Data as ProjectVM;
            var dto = Mapper.Map<ProjectDto>(vm);



            // Save Project
            await DataProvider.Projects.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(ProjectVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Projects.Delete(record.Id);
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
