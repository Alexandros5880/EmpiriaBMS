using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubCategories;

public partial class ProjectSubCategories
{
    #region Data Grid
    private List<ProjectSubCategoryVM> _records = new List<ProjectSubCategoryVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectSubCategoryVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectSubCategoryVM _selectedRecord = new ProjectSubCategoryVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectSubCategoryVM> row)
    {
        _selectedRecord = row.Item as ProjectSubCategoryVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectsSubCategories.GetAll();
        _records = Mapper.Map<List<ProjectSubCategoryVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(ProjectSubCategoryVM record)
    {

    }

    private async Task _delete(ProjectSubCategoryVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project sub categories {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.ProjectsSubCategories.Delete(record.Id);
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
