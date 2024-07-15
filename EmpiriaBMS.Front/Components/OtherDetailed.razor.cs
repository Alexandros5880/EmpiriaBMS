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

    List<SupportiveWorkTypeDto> _otherTypes = new List<SupportiveWorkTypeDto>();
    private SupportiveWorkVM _other = new SupportiveWorkVM();

    private async Task _getOtherTypes()
    {
        // TODO: SupportiveWorks Types Get By Discipline Id
        //var types = await DataProvider.SupportiveWorksTypes.GetOtherTypesSelections(DisciplineId);
        var types = await DataProvider.SupportiveWorksTypes.GetAll();
        _otherTypes = types.ToList();
    }

    public async void PrepairForNew()
    {
        isNew = true;
        _otherTypes.Clear();
        await _getOtherTypes();
        _other = new SupportiveWorkVM();
        _other.DisciplineId = DisciplineId;
        _other.TypeId = _otherTypes.FirstOrDefault().Id;
        StateHasChanged();
    }

    public async void PrepairForEdit(SupportiveWorkVM other)
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
        SupportiveWorkDto myOther = Mapper.Map<SupportiveWorkDto>(_other);
        // Save Other
        SupportiveWorkDto saveOther;
        var exists = await DataProvider.SupportiveWorks.Any(p => p.Id == _other.Id);
        if (exists)
            saveOther = await DataProvider.SupportiveWorks.Update(myOther);
        else
            saveOther = await DataProvider.SupportiveWorks.Add(myOther);
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
