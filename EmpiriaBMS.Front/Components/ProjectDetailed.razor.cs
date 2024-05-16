using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using System.Linq.Expressions;
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
    private List<ProjectSubCategoryDto> ProjectSubCategories = new List<ProjectSubCategoryDto>();
    private List<ProjectStageDto> ProjectStages = new List<ProjectStageDto>();
    private List<ProjectCategoryDto> ProjectCategories = new List<ProjectCategoryDto>();

    [Parameter]
    public ProjectVM Project { get; set; } = new ProjectVM();

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    private async Task _getProjectSubCategories(int id = 0)
    {
        ProjectSubCategories.Clear();
        if (id == 0)
            ProjectSubCategories = (await DataProvider.ProjectsSubCategories.GetAll()).ToList();
        else
            ProjectSubCategories = (await DataProvider.ProjectsSubCategories.GetAll(id)).ToList();
    }

    private async Task _getProjectStages()
    {
        ProjectStages.Clear();
        ProjectStages = (await DataProvider.ProjectStages.GetAll()).ToList();
    }

    private async Task _getProjectCategories()
    {
        ProjectCategories.Clear();
        ProjectCategories = (await DataProvider.ProjectsCategories.GetAll()).ToList();
    } 

    public async void PrepairForNew()
    {
        isNew = true;
        await _getProjectSubCategories();
        await _getProjectStages();
        await _getProjectCategories();
        Project = new ProjectVM();
        Project.Active = true;
        Project.CategoryId = 0;
        Project.StageId = 0;
        Project.CategoryId = 0;
        await _map.Search();
        StateHasChanged();
    }

    public async void PrepairForEdit(ProjectVM project = null)
    {
        isNew = false;
        await _getProjectSubCategories();
        await _getProjectStages();
        await _getProjectCategories();
        if (project != null)
            Project = project;
        await _map.SetAddress(Project.Address);
        StateHasChanged();
    }

    private async Task _updateProjectCategory(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        // Get SubCategories if If Projects Category Parent is Diffrent
        if (Project.Category?.CategoryId != id)
        {
            await _getProjectSubCategories(id);
            StateHasChanged();
        } else
        {
            ProjectSubCategories.Clear();
            StateHasChanged();
        }
    }

    private void _updateProjectStage(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        Project.StageId = id;
        var dto = ProjectStages.FirstOrDefault(g => g.Id == id);
        Project.Stage = Mapping.Mapper.Map<ProjectStage>(dto);
    }

    private void _updateProjectSubCategory(ChangeEventArgs e)
    {
        var id = Convert.ToInt32(e.Value);
        Project.CategoryId = id;
        var dto = ProjectSubCategories.FirstOrDefault(g => g.Id == id);
        Project.Category = Mapping.Mapper.Map<ProjectSubCategory>(dto);
        _validator.ValidateProperty(Project, nameof(ProjectVM.CategoryId), Project.CategoryId);
        StateHasChanged();
    }

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Project.Address = address;
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            Project.Category = null;
            Project.Stage = null;
            Project.Category = null;

            // If Addres Save Address
            if(Project?.Address != null && !(await DataProvider.Address.Any(a => a.PlaceId.Equals(Project.Address.PlaceId))))
            {
                var dto = Mapping.Mapper.Map<AddressDto>(Project.Address);
                var address = await DataProvider.Address.Add(dto);
                Project.AddressId = address.Id;
            }
            else if (Project?.Address != null && (await DataProvider.Address.Any(a => a.PlaceId.Equals(Project.Address.PlaceId))))
            {
                var dto = Mapping.Mapper.Map<AddressDto>(Project.Address);
                var address = await DataProvider.Address.Update(dto);
            }

            // Save Project
            ProjectDto saveProject;
            var exists = await DataProvider.Projects.Any(p =>  p.Id == Project.Id);
            if (exists)
                saveProject = await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(Project));
            else
                saveProject = await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(Project));

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
