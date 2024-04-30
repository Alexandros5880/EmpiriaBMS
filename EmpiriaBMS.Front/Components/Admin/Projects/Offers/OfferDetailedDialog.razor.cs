using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Offers;

public partial class OfferDetailedDialog : IDialogContentComponent<OfferVM>
{
    [Parameter]
    public OfferVM Content { get; set; } = default!;

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
                var typeDto = Mapping.Mapper.Map<OfferTypeDto>(Content.Type);
                Type = _mapper.Map<OfferTypeVM>(typeDto);
            }

            if (Content.State != null)
            {
                var stateDto = Mapping.Mapper.Map<OfferStateDto>(Content.State);
                State = _mapper.Map<OfferStateVM>(stateDto);
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
    private bool validCode = true;
    private bool validType = true;
    private bool validState = true;
    private bool validPudgetPrice = true;
    private bool validOfferPrice = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = Content.ProjectId != 0 && Content.ProjectId != null;
            validCode = !string.IsNullOrEmpty(Content.Code);
            validType = Content.TypeId != 0;
            validState = Content.StateId != 0;
            validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
            validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;

            return validCode && validType && validState && validProject && validPudgetPrice && validOfferPrice;
        }
        else
        {
            validProject = true;
            validCode = true;
            validType = true;
            validState = true;
            validPudgetPrice = true;
            validOfferPrice = true;

            switch (fieldname)
            {
                case "Project":
                    validProject = Content.ProjectId != 0 && Content.ProjectId != null;
                    return validProject;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    return validCode;
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;
                case "State":
                    validState = Content.StateId != 0;
                    return validState;
                case "PudgetPrice":
                    validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
                    return validPudgetPrice;
                case "OfferPrice":
                    validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;
                    return validOfferPrice;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<OfferTypeVM> _types = new ObservableCollection<OfferTypeVM>();
    ObservableCollection<OfferStateVM> _states = new ObservableCollection<OfferStateVM>();

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

    private OfferTypeVM _type = new OfferTypeVM();
    public OfferTypeVM Type
    {
        get => _type;
        set
        {
            if (_type == value || value == null) return;
            _type = value;
            Content.TypeId = _type.Id;
        }
    }

    private OfferStateVM _state = new OfferStateVM();
    public OfferStateVM State
    {
        get => _state;
        set
        {
            if (_state == value || value == null) return;
            _state = value;
            Content.StateId = _state.Id;
        }
    }

    private async Task _getRecords()
    {
        await _getProjects();
        await _getTypes();
        await _getStates();
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
        var dtos = await _dataProvider.OfferTypes.GetAll();
        var vms = _mapper.Map<List<OfferTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }

    private async Task _getStates()
    {
        var dtos = await _dataProvider.OfferStates.GetAll();
        var vms = _mapper.Map<List<OfferStateVM>>(dtos);
        _states.Clear();
        vms.ForEach(_states.Add);
    }
    #endregion
}