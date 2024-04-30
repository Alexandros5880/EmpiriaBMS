using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Disciplines;

public partial class DisciplineDetailedDialog : IDialogContentComponent<DisciplineVM>
{
    [Parameter]
    public DisciplineVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Content.Project != null)
            {
                var projectDto = Mapping.Mapper.Map<ProjectDto>(Content.Project);
                Project = _mapper.Map<ProjectVM>(projectDto);
            }

            if (Content.Type != null)
            {
                var typeDto = Mapping.Mapper.Map<DisciplineTypeDto>(Content.Type);
                Type = _mapper.Map<DisciplineTypeVM>(typeDto);
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
    private bool validProject = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validType = Content.TypeId != 0;
            validProject = Content.ProjectId != 0;

            return validType && validProject;
        }
        else
        {
            validType = true;
            validProject = true;

            switch (fieldname)
            {
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;
                case "Project":
                    validProject = Content.ProjectId != 0;
                    return validProject;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<DisciplineTypeVM> _types = new ObservableCollection<DisciplineTypeVM>();

    private ProjectVM _project = new ProjectVM();
    public ProjectVM Project
    {
        get => _project;
        set
        {
            if (_project == value || value == null) return;
            _project = value;
            Content.ProjectId = _project.Id;
        }
    }

    private DisciplineTypeVM _type = new DisciplineTypeVM();
    public DisciplineTypeVM Type
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
        await _getProjects();
        await _getTypes();
    }

    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = _mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        vms.ForEach(_projects.Add);
    }

    private async Task _getTypes()
    {
        var dtos = await _dataProvider.DisciplinesTypes.GetAll();
        var vms = _mapper.Map<List<DisciplineTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }
    #endregion
}