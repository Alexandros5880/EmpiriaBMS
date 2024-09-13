using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class DeliverableDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public int DisciplineId { get; set; }

    List<DeliverableTypeDto> _drawingTypes = new List<DeliverableTypeDto>();
    private DeliverableVM _drawing = new DeliverableVM();

    public DeliverableVM GetDeliverable() => _drawing;

    private async Task _getDrawingTypes()
    {
        // TODO: Deliverables Types Get By Discipline Id
        //var types = await DataProvider.DeliverablesTypes.GetDrawingTypesSelections(DisciplineId);
        var types = await DataProvider.DeliverablesTypes.GetAll();
        _drawingTypes = types.ToList();
    }

    public async void PrepairForNew()
    {
        isNew = true;
        _drawingTypes.Clear();
        await _getDrawingTypes();
        _drawing = new DeliverableVM();
        _drawing.DisciplineId = DisciplineId;
        _drawing.TypeId = _drawingTypes.FirstOrDefault()?.Id;
        StateHasChanged();
    }

    public async void PrepairForEdit(DeliverableVM drawing)
    {
        isNew = false;
        _drawingTypes.Clear();
        await _getDrawingTypes();
        _drawing = drawing;
        StateHasChanged();
    }

    private async Task _updateDrawingType(ChangeEventArgs e)
    {
        var pdrawingTypeId = Convert.ToInt32(e.Value);
        var drawingType = _drawingTypes.FirstOrDefault(t => t.Id == pdrawingTypeId);
        _drawing.TypeId = pdrawingTypeId;
        _drawing.Type = null;

        await _getDrawingTypes();
    }

    public async Task HandleValidSubmit()
    {
        DeliverableDto myDrawing = Mapper.Map<DeliverableDto>(_drawing);
        // Save Drawing
        DeliverableDto saveDrawing;
        var exists = await DataProvider.Deliverables.Any(p => p.Id == _drawing.Id);
        if (exists)
            saveDrawing = await DataProvider.Deliverables.Update(myDrawing);
        else
            saveDrawing = await DataProvider.Deliverables.Add(myDrawing);

        _drawing = Mapper.Map<DeliverableVM>(saveDrawing);
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
