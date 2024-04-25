using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Categories;

public partial class ProjectCategories
{
    #region Data Grid
    private List<ProjectCategoryVM> _records = new List<ProjectCategoryVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectCategoryVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectCategoryVM _selectedRecord = new ProjectCategoryVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectCategoryVM> row)
    {
        _selectedRecord = row.Item as ProjectCategoryVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll();
        _records = Mapper.Map<List<ProjectCategoryVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(ProjectCategoryVM record)
    {

    }

    private async Task _delete(ProjectCategoryVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the project category {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.ProjectsCategories.Delete(record.Id);
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
