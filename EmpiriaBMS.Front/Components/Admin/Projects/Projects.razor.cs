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

    private ProjectVM _selectedRecord = new ProjectVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectVM> row)
    {
        _selectedRecord = row.Item as ProjectVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Projects.GetAll();
        _records = Mapper.Map<List<ProjectVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(ProjectVM record)
    {

    }

    private void _delete(ProjectVM record)
    {

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
