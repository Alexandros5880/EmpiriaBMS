using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.OthersTypes;

public partial class OthersTypes
{
    private Paginator _paginator;
    private ObservableCollection<OtherTypeVM> _source = new ObservableCollection<OtherTypeVM>();
    private OtherTypeVM _selectedItem = new OtherTypeVM();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _paginator.SetRecordsLength(await DataProvider.OthersTypes.Count());
            await _getSource();

            StateHasChanged();
        }
    }

    private async Task _getSource()
    {
        var dtos = await DataProvider.OthersTypes.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<OtherTypeVM>>(dtos);
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
