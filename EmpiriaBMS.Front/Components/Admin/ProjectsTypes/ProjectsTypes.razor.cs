using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.ProjectsTypes;

public partial class ProjectsTypes
{
    private Paginator _paginator;
    private ObservableCollection<ProjectCategoryVM> _source = new ObservableCollection<ProjectCategoryVM>();
    private ProjectCategoryVM _selectedItem = new ProjectCategoryVM();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _paginator.SetRecordsLength(await DataProvider.ProjectsCategories.Count());
            await _getSource();

            StateHasChanged();
        }
    }

    private async Task _getSource()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<ProjectCategoryVM>>(dtos);
        _source.Clear();
        vms.ForEach(_source.Add);
    }

    private void _onSelectItem(int id)
    {
        _selectedItem = _source.FirstOrDefault(r => r.Id == id);
    }

    protected override bool ShouldRender()
    {
        // Return false to prevent the entire component from re-rendering
        return true;
    }
}
