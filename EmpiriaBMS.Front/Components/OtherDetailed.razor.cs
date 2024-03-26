using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class OtherDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public int DisciplineId { get; set; }

    List<OtherTypeDto> _otherTypes = new List<OtherTypeDto>();
    private OtherVM _other = new OtherVM();

    private async Task _getOtherTypes()
    {
        var types = await DataProvider.OthersTypes.GetOtherTypesSelections(DisciplineId);
        _otherTypes = types.ToList();
    }

    public async void PrepairForNew()
    {
        isNew = true;
        _otherTypes.Clear();
        await _getOtherTypes();
        _other = new OtherVM();
        _other.DisciplineId = DisciplineId;
        _other.TypeId = _otherTypes.FirstOrDefault().Id;
        StateHasChanged();
    }

    public async void PrepairForEdit(OtherVM other)
    {
        isNew = false;
        _otherTypes.Clear();
        await _getOtherTypes();
        _other = other;
        StateHasChanged();
    }

    private async Task _updateOtherType(ChangeEventArgs e)
    {
        var pdrawingTypeId = Convert.ToInt32(e.Value);
        var drawingType = _otherTypes.FirstOrDefault(t => t.Id == pdrawingTypeId);
        _other.TypeId = pdrawingTypeId;
        _other.Type = null;

        await _getOtherTypes();
    }

    public async Task HandleValidSubmit()
    {
        OtherDto myOther = Mapper.Map<OtherDto>(_other);
        // Save Other
        OtherDto saveOther;
        var exists = await DataProvider.Others.Any(p => p.Id == _other.Id);
        if (exists)
            saveOther = await DataProvider.Others.Update(myOther);
        else
            saveOther = await DataProvider.Others.Add(myOther);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
