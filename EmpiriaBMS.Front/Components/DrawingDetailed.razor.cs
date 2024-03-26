using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Front.Components.Admin.DisciplinesTypes;
using System.Linq.Expressions;
using EmpiriaBMS.Front.Components.Admin.ProjectsTypes;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace EmpiriaBMS.Front.Components;

public partial class DrawingDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public int DisciplineId { get; set; }

    List<DrawingTypeDto> _drawingTypes = new List<DrawingTypeDto>();
    private DrawingVM _drawing = new DrawingVM();

    private async Task _getDrawingTypes()
    {
        var types = await DataProvider.DrawingsTypes.GetDrawingTypesSelections(DisciplineId);
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
