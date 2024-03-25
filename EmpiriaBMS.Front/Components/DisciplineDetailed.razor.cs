using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class DisciplineDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public int ProjectId { get; set; }

    List<DrawingTypeDto> _drawingTypes = new List<DrawingTypeDto>();
    private DrawingVM _drawing = new DrawingVM();

    private async Task _getDrawingTypes()
    {
        var types = await DataProvider.DrawingsTypes.GetAll();
        _drawingTypes = types.ToList();
    }

    public async void PrepairForNew()
    {
        isNew = true;
        _drawingTypes.Clear();
        await _getDrawingTypes();
        _drawing = new DrawingVM();
        _drawing.TypeId = _drawingTypes.FirstOrDefault().Id;
        StateHasChanged();
    }

    public async void PrepairForEdit(DrawingVM drawing)
    {
        isNew = false;
        _drawingTypes.Clear();
        await _getDrawingTypes();
        _drawing = drawing;
        StateHasChanged();
    }

    private void _updateDrawingType(ChangeEventArgs e)
    {
        var pdrawingTypeId = Convert.ToInt32(e.Value);
        var drawingType = _drawingTypes.FirstOrDefault(t => t.Id == pdrawingTypeId);
        _drawing.TypeId = pdrawingTypeId;
        _drawing.Type = null;
    }

    public async Task HandleValidSubmit()
    {
        DrawingDto myDrawing = Mapper.Map<DrawingDto>(_drawing);
        // Save Drawing
        DrawingDto saveDrawing;
        var exists = await DataProvider.Drawings.Any(p => p.Id == _drawing.Id);
        if (exists)
            saveDrawing = await DataProvider.Drawings.Update(myDrawing);
        else
            saveDrawing = await DataProvider.Drawings.Add(myDrawing);
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
