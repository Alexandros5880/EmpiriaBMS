using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Invoices;

public partial class InvoiceDetailedDialog : IDialogContentComponent<InvoiceVM>
{
    [Parameter]
    public InvoiceVM Content { get; set; } = default!;

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
                var projectDto = _mapper.Map<ProjectDto>(Content.Project);
                Project = _mapper.Map<ProjectVM>(projectDto);
            }

            if (Content.Type != null)
            {
                var typeDto = _mapper.Map<InvoiceTypeDto>(Content.Type);
                Type = _mapper.Map<InvoiceTypeVM>(typeDto);
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
    private bool validProject = true;
    private bool validMark = true;
    private bool validType = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = Content.ProjectId != 0 && Content.ProjectId != null;
            validMark = !string.IsNullOrEmpty(Content.Mark);
            validType = Content.TypeId != 0;


            return validMark && validType && validProject;
        }
        else
        {
            validProject = true;
            validMark = true;
            validType = true;

            switch (fieldname)
            {
                case "Project":
                    validProject = Content.ProjectId != 0 && Content.ProjectId != null;
                    return validProject;
                case "Mark":
                    validMark = !string.IsNullOrEmpty(Content.Mark);
                    return validMark;
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;

                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<InvoiceTypeVM> _types = new ObservableCollection<InvoiceTypeVM>();

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

    private InvoiceTypeVM _type = new InvoiceTypeVM();
    public InvoiceTypeVM Type
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
        var dtos = await _dataProvider.InvoiceTypes.GetAll();
        var vms = _mapper.Map<List<InvoiceTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }
    #endregion
}