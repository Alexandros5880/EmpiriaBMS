using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Front.Components;

public partial class DisciplineDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;

    [Parameter]
    public int ProjectId { get; set; }

    List<DisciplineTypeDto> _disciplineTypes = new List<DisciplineTypeDto>();
    private DisciplineVM _discipline = new DisciplineVM();

    public DisciplineVM GetDiscipline() => _discipline;

    private async Task _getDisciplineTypes()
    {
        var types = await DataProvider.DisciplinesTypes.GetAll();
        _disciplineTypes = types.ToList();
    }

    public async Task PrepairForNew()
    {
        _disciplineTypes.Clear();
        await _getDisciplineTypes();
        _discipline = new DisciplineVM();
        _discipline.ProjectId = ProjectId;
        _discipline.TypeId = _disciplineTypes.FirstOrDefault().Id;
        StateHasChanged();
    }

    public async Task PrepairForEdit(DisciplineVM discipline)
    {
        _disciplineTypes.Clear();
        await _getDisciplineTypes();
        _discipline = discipline;
        StateHasChanged();
    }

    private async Task _updateDisciplineType(ChangeEventArgs e)
    {
        var pdisciplineTypeId = Convert.ToInt32(e.Value);
        var disciplineType = _disciplineTypes.FirstOrDefault(t => t.Id == pdisciplineTypeId);
        _discipline.TypeId = pdisciplineTypeId;
        _discipline.Type = null;
        
        await _getDisciplineTypes();
    }

    public async Task HandleValidSubmit()
    {
        DisciplineDto myDiscipline = Mapper.Map<DisciplineDto>(_discipline);
        // Save Discipline
        DisciplineDto saveDiscipline;
        var exists = await DataProvider.Disciplines.Any(p => p.Id == _discipline.Id);
        if (exists)
            saveDiscipline = await DataProvider.Disciplines.Update(myDiscipline);
        else
            saveDiscipline = await DataProvider.Disciplines.Add(myDiscipline);

        _discipline = Mapper.Map<DisciplineVM>(saveDiscipline);
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
