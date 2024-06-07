using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.SupportiveWorks;

public partial class SupportiveWorkDetailedDialog : IDialogContentComponent<OtherVM>
{
    [Parameter]
    public OtherVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Content.Discipline != null)
            {
                var disciplineDto = Mapping.Mapper.Map<DisciplineDto>(Content.Discipline);
                Discipline = _mapper.Map<DisciplineVM>(disciplineDto);
            }

            if (Content.Type != null)
            {
                var typeDto = Mapping.Mapper.Map<OtherTypeDto>(Content.Type);
                Type = _mapper.Map<OtherTypeVM>(typeDto);
            }

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Validation
    private bool validType = true;
    private bool validDiscipline = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validType = Content.TypeId != 0 && Content.TypeId != null;
            validDiscipline = Content.DisciplineId != 0 && Content.DisciplineId != null;

            return validType && validDiscipline;
        }
        else
        {
            validType = true;
            validDiscipline = true;

            switch (fieldname)
            {
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;
                case "Discipline":
                    validDiscipline = Content.DisciplineId != 0;
                    return validDiscipline;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<DisciplineVM> _disciplines = new ObservableCollection<DisciplineVM>();
    ObservableCollection<OtherTypeVM> _types = new ObservableCollection<OtherTypeVM>();

    private DisciplineVM _discipline = new DisciplineVM();
    public DisciplineVM Discipline
    {
        get => _discipline;
        set
        {
            if (_discipline == value || value == null) return;
            _discipline = value;
            Content.DisciplineId = _discipline.Id;
        }
    }

    private OtherTypeVM _type = new OtherTypeVM();
    public OtherTypeVM Type
    {
        get => _type;
        set
        {
            if (_type == value || value == null) return;
            _type = value;
            Content.TypeId = _type.Id;
        }
    }

    private async Task _getRecords()
    {
        await _getDiscipline();
        await _getTypes();
    }

    private async Task _getDiscipline()
    {
        var dtos = await _dataProvider.Disciplines.GetAll();
        var vms = _mapper.Map<List<DisciplineVM>>(dtos);
        _disciplines.Clear();
        vms.ForEach(_disciplines.Add);
    }

    private async Task _getTypes()
    {
        var dtos = await _dataProvider.OthersTypes.GetAll();
        var vms = _mapper.Map<List<OtherTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }
    #endregion
}