using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects;

public partial class Projects
{
    private Paginator _paginator;
    private ObservableCollection<ProjectVM> _source = new ObservableCollection<ProjectVM>();
    private ProjectVM _selectedItem = new ProjectVM();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var prevPage = pageCached.GetPage<Projects>();
            if (prevPage != null)
            {
                _source = prevPage._source;
                _selectedItem = prevPage._selectedItem;
                _paginator.SetVM(prevPage._paginator.Peginator);
            }
            else
            {
                pageCached.AddPage(this);
                _paginator.SetRecordsLength(await DataProvider.Projects.Count());
                await _getSource();
            }

            StateHasChanged();
        }
    }

    private async Task _getSource()
    {
        var dtos = await DataProvider.Projects.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<ProjectVM>>(dtos);
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
