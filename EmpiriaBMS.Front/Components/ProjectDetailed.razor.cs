using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Web;
using EmpiriaBMS.Front.Components.General;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetailed : ComponentBase
{
    private FluentCombobox<ProjectSubCategoryVM> _subCatCombo;

    private ProjectVM _project;
    [Parameter]
    public ProjectVM Content
    {
        get => _project;
        set
        {
            _project = value ?? new ProjectVM();
        }
    }

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    public bool _isNew => Content?.Id != 0 && Content?.Id != null;

    ObservableCollection <ProjectCategoryVM> _categories = new ObservableCollection<ProjectCategoryVM>();
    ObservableCollection<ProjectSubCategoryVM> _subCategories = new ObservableCollection<ProjectSubCategoryVM>();
    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();
    ObservableCollection<UserVM> _pms = new ObservableCollection<UserVM>();

    public ProjectCategoryVM _category = new ProjectCategoryVM();
    public ProjectCategoryVM Category
    {
        get => _category;
        set
        {
            if (_category == value || value == null) return;
            _category = value;
            if (Content.Category != null)
                Content.Category.CategoryId = _category.Id;
            _getSubCategories(refresh: true);
        }
    }

    private ProjectSubCategoryVM _subCategory = new ProjectSubCategoryVM();
    public ProjectSubCategoryVM SubCategory
    {
        get => _subCategory;
        set
        {
            if (_subCategory == value || value == null) return;
            _subCategory = value;
            Content.CategoryId = _subCategory?.Id ?? 0;
            var subCat = _subCategories.FirstOrDefault(c => c.Id == _subCategory.Id);
            var dto = Mapper.Map<ProjectSubCategoryDto>(subCat);
            Content.Category = Mapping.Mapper.Map<ProjectSubCategory>(dto);

            Content.Category.CategoryId = Category.Id;
            var parentCatDto = Mapper.Map<ProjectCategoryDto>(Category);
            Content.Category.Category = Mapping.Mapper.Map<ProjectCategory>(parentCatDto);
        }
    }

    private ProjectStageVM _stage = new ProjectStageVM();
    public ProjectStageVM Stage
    {
        get => _stage;
        set
        {
            if (_stage == value || value == null) return;
            _stage = value;
            Content.StageId = _stage.Id;
        }
    }

    private UserVM _pm = new UserVM();
    public UserVM Pm
    {
        get => _pm;
        set
        {
            if (_pm == value || value == null) return;
            _pm = value;
            Content.ProjectManagerId = _pm.Id;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair()
    {
        await _getRecords();

        StateHasChanged();
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid)
            return;

        try
        {
            Content.Category = null;
            Content.Stage = null;
            Content.Category = null;

            // Save Project
            ProjectDto saveProject;
            var exists = await DataProvider.Projects.Any(p => p.Id == Content.Id);
            if (exists)
                saveProject = await DataProvider.Projects.Update(Mapper.Map<ProjectDto>(Content));
            else
                saveProject = await DataProvider.Projects.Add(Mapper.Map<ProjectDto>(Content));

            if (saveProject == null)
                throw new NullReferenceException(nameof(saveProject));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    public ProjectVM GetProject() => Content as ProjectVM;

    #region Client && Autocomplete
    private bool _diplayedClientForm = false;
    private ClientVM _backupClient;


    #endregion

    #region Validation
    private bool validName = true;
    private bool validCode = true;
    private bool validCategory = true;
    private bool validSubCategory = true;
    private bool validStage = true;
    private bool validPm = true;
    private bool validEstHours = true;

    public bool Validate(string fieldname = null)
    {
        var valid = false;
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validCategory = _category != null && _category.Id != 0;
            validSubCategory = _subCategory != null && _subCategory.Id != 0;
            validStage = _stage != null && _stage.Id != 0;
            validPm = _pm != null && _pm.Id != 0;
            validEstHours = Content.EstimatedHours > 0;

            valid = validName && validCode && validCategory && validSubCategory && validStage && validPm && validEstHours;
        }
        else
        {
            validName = true;
            validCode = true;
            validCategory = true;
            validStage = true;
            validPm = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    valid = validName;
                    break;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    valid = validCode;
                    break;
                case "Category":
                    validCategory = _category != null && _category.Id != 0;
                    valid = validCategory;
                    break;
                case "SubCategory":
                    validSubCategory = _subCategory != null && _subCategory.Id != 0;
                    valid = validSubCategory;
                    break;
                case "Stage":
                    validStage = _stage != null && _stage.Id != 0;
                    valid = validStage;
                    break;
                case "PM":
                    validPm = _pm != null && _pm.Id != 0;
                    valid = validPm;
                    break;
                case "EstimatedHours":
                    validEstHours = Content.EstimatedHours > 0;
                    valid = validEstHours;
                    break;
                default:
                    valid = true;
                    break;
            }
        }
        StateHasChanged();
        return valid;
    }
    #endregion

    #region Get Related Records
    private async Task _getRecords()
    {
        await _getCategories();
        await _getStages();
        await _getProjectManagers();
    }

    private async Task _getCategories()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll();
        var vms = Mapper.Map<List<ProjectCategoryVM>>(dtos);
        _categories.Clear();
        vms.ForEach(_categories.Add);

        Category = _categories.FirstOrDefault(c => c.Id == Content.Category?.CategoryId) ?? null;
        SubCategory = null;
    }

    private async Task _getSubCategories(bool refresh = false)
    {
        if (_category == null) return;
        var dtos = await DataProvider.ProjectsSubCategories.GetAll(_category.Id);
        var vms = Mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _subCategories.Clear();
        vms.ForEach(_subCategories.Add);

        SubCategory = _subCategories.FirstOrDefault(c => c.CategoryId == _category.Id) ?? null;
        _subCatCombo.Value = SubCategory.Name;
        _subCatCombo.SelectedOption = SubCategory;

        if (refresh)
            StateHasChanged();
    }

    private async Task _getStages()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        var vms = Mapper.Map<List<ProjectStageVM>>(dtos);
        _stages.Clear();
        vms.ForEach(_stages.Add);

        Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId) ?? null;
    }

    private async Task _getProjectManagers()
    {
        var dtos = await DataProvider.Users.GetProjectManagers();
        var vms = Mapper.Map<List<UserVM>>(dtos);
        _pms.Clear();
        vms.ForEach(_pms.Add);

        Pm = _pms.FirstOrDefault(c => c.Id == Content.ProjectManagerId) ?? null;
    }
    #endregion

    #region Map Address
    private Map _myMapRef;

    private void _onSearchAddressChange()
    {
        //var address = _myMapRef.GetAddress();
        //if (address != null)
        //    Content.Address = address;
    }
    #endregion
}
