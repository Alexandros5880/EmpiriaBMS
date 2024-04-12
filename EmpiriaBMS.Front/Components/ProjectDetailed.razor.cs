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
using EmpiriaBMS.Front.ViewModel.Validation;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Web;
using EmpiriaBMS.Front.Components.General;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;
    private string defaultCodeValue = "*******";
    private Map _map;

    #region Authorization Properties
    bool seeCode => _sharedAuthData.Permissions.Any(p => p.Ord == 13);
    #endregion

    private ProjectValidator _validator = new ProjectValidator();
    private List<ProjectSubCategoryDto> _projectSubCategories = new List<ProjectSubCategoryDto>();
    private List<ProjectStageDto> _projectStages = new List<ProjectStageDto>();
    private List<ProjectCategoryDto> _projectCategories = new List<ProjectCategoryDto>();
    private ProjectVM _project = new ProjectVM();

    private async Task _getProjectSubCategories()
    {
        _projectSubCategories.Clear();
        _projectSubCategories = (await DataProvider.ProjectsSubCategories.GetAll()).ToList();
    }

    private async Task _getProjectStages()
    {
        _projectStages.Clear();
        _projectStages = (await DataProvider.ProjectStages.GetAll()).ToList();
    }

    private async Task _getProjectCategories()
    {
        _projectCategories.Clear();
        _projectCategories = (await DataProvider.ProjectsCategories.GetAll()).ToList();
    } 

    public async void PrepairForNew()
    {
        isNew = true;
        await _getProjectSubCategories();
        await _getProjectStages();
        await _getProjectCategories();
        _project = new ProjectVM();
        _project.Active = true;
        _project.SubCategoryId = 0;
        _project.StageId = 0;
        _project.CategoryId = 0;
        await _map.Search(null);
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project)
    {
        isNew = false;
        await _getProjectSubCategories();
        await _getProjectStages();
        await _getProjectCategories();
        _project = project;
        await _map.SetAddress(project.Address);
        StateHasChanged();
    }

    private void _updateProjectCategory(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        _project.CategoryId = id;
        var dto = _projectCategories.FirstOrDefault(g => g.Id == id);
        _project.Category = Mapping.Mapper.Map<ProjectCategory>(dto);
    }

    private void _updateProjectStage(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        _project.StageId = id;
        var dto = _projectStages.FirstOrDefault(g => g.Id == id);
        _project.Stage = Mapping.Mapper.Map<ProjectStage>(dto);
    }

    private void _updateProjectSubCategory(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        _project.SubCategoryId = id;
        var dto = _projectSubCategories.FirstOrDefault(g => g.Id == id);
        _project.SubCategory = Mapping.Mapper.Map<ProjectSubCategory>(dto);

        _validator.ValidateProperty(_project, nameof(ProjectVM.SubCategoryId), _project.SubCategoryId);
        StateHasChanged();
    }

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            _project.Address = address;
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            _project.SubCategory = null;
            _project.Stage = null;
            _project.Category = null;

            // If Addres Save Address
            if(_project?.Address != null && !(await DataProvider.Address.Any(a => a.PlaceId.Equals(_project.Address.PlaceId))))
            {
                var dto = Mapping.Mapper.Map<AddressDto>(_project.Address);
                var address = await DataProvider.Address.Add(dto);
                _project.AddressId = address.Id;
            }
            else if (_project?.Address != null && (await DataProvider.Address.Any(a => a.PlaceId.Equals(_project.Address.PlaceId))))
            {
                var dto = Mapping.Mapper.Map<AddressDto>(_project.Address);
                var address = await DataProvider.Address.Update(dto);
            }

            // Save Project
            ProjectDto saveProject;
            var exists = await DataProvider.Projects.Any(p =>  p.Id == _project.Id);
            if (exists)
                saveProject = await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(_project));
            else
                saveProject = await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(_project));

            if (saveProject == null)
                throw new NullReferenceException(nameof(saveProject));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
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
