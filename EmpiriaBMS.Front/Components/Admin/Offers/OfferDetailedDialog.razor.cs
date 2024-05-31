using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Admin.Offers;

public partial class OfferDetailedDialog : IDialogContentComponent<OfferVM>
{
    private FluentCombobox<ProjectSubCategoryVM> _subCatCombo;

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

            if (Content.Result != null)
            {
                SelectedResult = _results.FirstOrDefault(r => r.Value == Content.Result.ToString());
            }

            // Category
            if (Content.Category != null)
            {
                Category = _categories.FirstOrDefault(s => s.Id == Content.CategoryId);
            }
            else if (Content.CategoryId != 0)
            {
                Category = _categories.FirstOrDefault(s => s.Id == Content.CategoryId);
            }

            // SubCategory
            if (Content.SubCategory != null)
            {
                SubCategory = _subCategories.FirstOrDefault(s => s.Id == Content.SubCategoryId);
            }
            else if (Content.SubCategoryId != 0)
            {
                SubCategory = _subCategories.FirstOrDefault(s => s.Id == Content.SubCategoryId);
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
    private bool validCode = true;
    private bool validType = true;
    private bool validState = true;
    private bool validDate = true;
    private bool validPudgetPrice = true;
    private bool validOfferPrice = true;
    private bool validCategory = true;
    private bool validSubCategory = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validCode = !string.IsNullOrEmpty(Content.Code);
            validType = Content.TypeId != 0;
            validState = Content.StateId != 0;
            validDate = Content.Date == null ? false : ((DateTime)Content.Date) >= DateTime.Now;
            validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
            validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;
            validCategory = _category != null && _category.Id != 0;
            validSubCategory = _subCategory != null && _subCategory.Id != 0;

            return validCode && validType && validState && validDate && validPudgetPrice && validOfferPrice && validCategory && validSubCategory;
        }
        else
        {
            validCode = true;
            validType = true;
            validState = true;
            validDate = true;
            validPudgetPrice = true;
            validOfferPrice = true;
            validCategory = true;

            switch (fieldname)
            {
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    return validCode;
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;
                case "State":
                    validState = Content.StateId != 0;
                    return validState;
                case "Date":
                    validDate = Content.Date == null ? false : ((DateTime)Content.Date) >= DateTime.Now;
                    return validDate;
                case "PudgetPrice":
                    validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
                    return validPudgetPrice;
                case "OfferPrice":
                    validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;
                    return validOfferPrice;
                case "Category":
                    validCategory = _category != null && _category.Id != 0;
                    return validCategory;
                case "SubCategory":
                    validSubCategory = _subCategory != null && _subCategory.Id != 0;
                    return validSubCategory;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<OfferTypeVM> _types = new ObservableCollection<OfferTypeVM>();
    ObservableCollection<OfferStateVM> _states = new ObservableCollection<OfferStateVM>();
    ObservableCollection<ProjectCategoryVM> _categories = new ObservableCollection<ProjectCategoryVM>();
    ObservableCollection<ProjectSubCategoryVM> _subCategories = new ObservableCollection<ProjectSubCategoryVM>();
    private List<(string Value, string Text)> _results = Enum.GetValues(typeof(OfferResult))
                                                             .Cast<OfferResult>()
                                                             .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                                .First()
                                                                .GetCustomAttribute<DisplayAttribute>()?
                                                                .GetName() ?? e.ToString()))
                                                             .ToList();

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

    public ProjectCategoryVM _category = new ProjectCategoryVM();
    public ProjectCategoryVM Category
    {
        get => _category;
        set
        {
            if (_category == value || value == null) return;
            _category = value;
            if (Content.Category != null)
                Content.CategoryId = _category.Id;
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
            var subCat = _subCategories.FirstOrDefault(c => c.Id == _subCategory.Id);
            var dto = _mapper.Map<ProjectSubCategoryDto>(subCat);
            Content.SubCategory = Mapping.Mapper.Map<ProjectSubCategory>(dto);
        }
    }

    private (string Value, string Text) _selectedResult;
    public (string Value, string Text) SelectedResult
    {
        get => _selectedResult;
        set
        {
            _selectedResult = value;
            OfferResult result = (OfferResult)Enum.Parse(typeof(OfferResult), value.Value);
            Content.Result = result;
        }
    }

    private async Task _getRecords()
    {
        await _getTypes();
        await _getStates();
        await _getCategories();
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

    private async Task _getCategories()
    {
        var dtos = await _dataProvider.ProjectsCategories.GetAll();
        var vms = _mapper.Map<List<ProjectCategoryVM>>(dtos);
        _categories.Clear();
        vms.ForEach(_categories.Add);

        Category = null;
        SubCategory = null;
    }

    private async Task _getSubCategories(bool refresh = false)
    {
        if (_category == null) return;
        var dtos = await _dataProvider.ProjectsSubCategories.GetAll(_category.Id);
        var vms = _mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _subCategories.Clear();
        vms.ForEach(_subCategories.Add);

        // SubCategory
        if (Content.SubCategory != null)
        {
            SubCategory = _subCategories.FirstOrDefault(s => s.Id == Content.SubCategoryId);
            _subCatCombo.Value = SubCategory.Name;
            _subCatCombo.SelectedOption = SubCategory;
        }
        else if (Content.SubCategoryId != 0)
        {
            SubCategory = _subCategories.FirstOrDefault(s => s.Id == Content.SubCategoryId);
            _subCatCombo.Value = SubCategory.Name;
            _subCatCombo.SelectedOption = SubCategory;
        }

        if (refresh)
            StateHasChanged();
    }
    #endregion
}