using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Stages;

public partial class Stages
{
    #region Data Grid
    private List<ProjectStageVM> _records = new List<ProjectStageVM>();
    private string _filterString = string.Empty;
    IQueryable<ProjectStageVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private ProjectStageVM _selectedRecord = new ProjectStageVM();

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

    private void HandleRowFocus(FluentDataGridRow<ProjectStageVM> row)
    {
        _selectedRecord = row.Item as ProjectStageVM;
    }

    private async Task _getRecords()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        _records = Mapper.Map<List<ProjectStageVM>>(dtos);
    }

    private void _add()
    {

    }

    private void _edit(ProjectStageVM record)
    {

    }

    private void _delete(ProjectStageVM record)
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
