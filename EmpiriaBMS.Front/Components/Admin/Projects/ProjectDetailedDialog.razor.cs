using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects;

public partial class ProjectDetailedDialog : IDialogContentComponent<ProjectVM>
{
    [Parameter]
    public ProjectVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    ObservableCollection<ProjectCategoryVM> _categories = new ObservableCollection<ProjectCategoryVM>();
    ObservableCollection<ProjectSubCategoryVM> _subCategories = new ObservableCollection<ProjectSubCategoryVM>();
    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();

    public ProjectCategoryVM _category;
    public ProjectCategoryVM Category
    {
        get => _category;
        set
        {
            if (_category == value) return;
            _category = value;
            Content.Category.CategoryId = _category.Id;
            _getSubCategories();
            SubCategory = null;
            StateHasChanged();
        }
    }
    
    private ProjectSubCategoryVM _subCategory;
    public ProjectSubCategoryVM SubCategory
    {
        get => _subCategory;
        set
        {
            if (_subCategory == value) return;
            _subCategory = value;
            Content.CategoryId = _subCategory?.Id ?? 0;
        }
    }

    private ProjectStageVM _stage;
    public ProjectStageVM Stage
    {
        get => _stage;
        set
        {
            if (_stage == value) return;
            _stage = value;
            Content.StageId = _stage.Id;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

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
    private bool validName = true;
    private bool validCode = true;
    private bool validCategory = true;
    private bool validSubCategory = true;
    private bool validStage = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validCategory = _category != null;
            validSubCategory = Content.CategoryId != 0;
            validStage = Content.StageId != 0;

            return validName && validCode && validCategory && validSubCategory && validStage;
        }
        else
        {
            validName = true;
            validCode = true;
            validCategory = true;
            validStage = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    return validCode;
                case "Category":
                    validCategory = _category != null;
                    return validCategory;
                case "SubCategory":
                    validSubCategory = Content.CategoryId != 0;
                    return validSubCategory;
                case "Stage":
                    validStage = Content.StageId != 0;
                    return validStage;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    private async Task _getRecords()
    {
        await _getCategories();
        await _getStages();
    }

    private async Task _getCategories()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll();
        var vms = Mapper.Map<List<ProjectCategoryVM>>(dtos);
        _categories.Clear();
        vms.ForEach(_categories.Add);

        Category = _categories.FirstOrDefault(c => c.Id == Content.Category.CategoryId) ?? null;
        SubCategory = null;
    }

    private async Task _getSubCategories()
    {
        if (_category == null) return;
        var dtos = await DataProvider.ProjectsSubCategories.GetAll(_category.Id);
        var vms = Mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _subCategories.Clear();
        vms.ForEach(_subCategories.Add);

        SubCategory = _subCategories.FirstOrDefault(c => c.Id == Content.CategoryId) ?? null;
    }

    private async Task _getStages()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        var vms = Mapper.Map<List<ProjectStageVM>>(dtos);
        _stages.Clear();
        vms.ForEach(_stages.Add);

        Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId) ?? null;
    }
    #endregion
}
