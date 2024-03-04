using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.DrawingsTypes;

public partial class DrawingsTypes
{
    private Paginator _paginator;
    private ObservableCollection<DrawingTypeVM> _source = new ObservableCollection<DrawingTypeVM>();
    private DrawingTypeVM _selectedItem = new DrawingTypeVM();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var pevLocation = previusLocationService.GetPreviousLocation();
            if (pevLocation?.GetType() == typeof(DrawingsTypes))
            {
                var prevPage = (DrawingsTypes)pevLocation;
                _source = prevPage._source;
                _selectedItem = prevPage._selectedItem;
                _paginator.SetVM(prevPage._paginator.Peginator);
            }
            else
            {
                previusLocationService.UpdatePreviousLocation(this);
                _paginator.SetRecordsLength(await DataProvider.DrawingsTypes.Count());
                await _getSource();
            }

            StateHasChanged();
        }
    }

    private async Task _getSource()
    {
        var dtos = await DataProvider.DrawingsTypes.GetAll(_paginator.PageSize, _paginator.PageIndex);
        var vms = Mapper.Map<List<DrawingTypeVM>>(dtos);
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
