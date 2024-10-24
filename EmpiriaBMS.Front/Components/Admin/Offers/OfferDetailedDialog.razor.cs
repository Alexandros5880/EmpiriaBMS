﻿using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Admin.Offers;

public partial class OfferDetailedDialog : IDialogContentComponent<OfferVM>
{
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private FluentCombobox<ClientVM> _clientCombo;
    private FluentCombobox<OfferTypeVM> _typeCombo;
    private FluentCombobox<OfferStateVM> _stateCombo;
    private FluentCombobox<(string Value, string Text)> _resultCombo;
    private FluentCombobox<ProjectCategoryVM> _catCombo;
    private FluentCombobox<ProjectSubCategoryVM> _subCatCombo;

    [Parameter]
    public OfferVM Content { get; set; }

    [Parameter]
    public EventCallback<OfferVM> OnSave { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    [Parameter]
    public EventCallback<(string Value, string Text)> OnResultChanged { get; set; }

    private bool _isNew => Content?.Id == 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair(OfferVM offer = null, bool full = true)
    {
        if (offer != null)
            Content = offer;

        if (full)
            await _getRecords();

        if (Content.Client != null)
        {
            var clientDto = Mapping.Mapper.Map<ClientDto>(Content.Client);
            Client = _mapper.Map<ClientVM>(clientDto);
            _clientCombo.Value = $"{Client.CompanyName} - {Client.Name}";
            _clientCombo.SelectedOption = Client;
        }
        else if (Content.ClientId != 0)
        {
            Client = _clients.FirstOrDefault(c => c.Id == Content.ClientId);
            _clientCombo.Value = $"{Client.CompanyName} - {Client.Name}";
            _clientCombo.SelectedOption = Client;
        }

        if (Content.Type != null)
        {
            var typeDto = Mapping.Mapper.Map<OfferTypeDto>(Content.Type);
            Type = _mapper.Map<OfferTypeVM>(typeDto);
            _typeCombo.Value = Type.Name;
            _typeCombo.SelectedOption = Type;
        }
        else if (Content.TypeId != 0)
        {
            Type = _types.FirstOrDefault(c => c.Id == Content.TypeId);
            _typeCombo.Value = Type.Name;
            _typeCombo.SelectedOption = Type;
        }

        if (Content.State != null)
        {
            var stateDto = Mapping.Mapper.Map<OfferStateDto>(Content.State);
            State = _mapper.Map<OfferStateVM>(stateDto);
            _stateCombo.Value = State.Name;
            _stateCombo.SelectedOption = State;
        }
        else if (Content.StateId != 0)
        {
            State = _states.FirstOrDefault(c => c.Id == Content.StateId);
            _stateCombo.Value = State.Name;
            _stateCombo.SelectedOption = State;
        }

        if (Content.Result != null)
        {
            SelectedResult = _results.FirstOrDefault(r => r.Value == Content.Result.ToString());
            if (_resultCombo != null)
            {
                _resultCombo.Value = SelectedResult.Value;
                _resultCombo.SelectedOption = SelectedResult;
            }
        }
        else
        {
            SelectedResult = _results.FirstOrDefault(r => r.Value == ClientResult.UNSUCCESSFUL.ToString());
            if (_resultCombo != null)
            {
                _resultCombo.Value = SelectedResult.Value;
                _resultCombo.SelectedOption = SelectedResult;
            }
        }

        // Category
        ProjectCategoryVM category = null;
        if (Content.Category != null)
        {
            category = _categories.FirstOrDefault(s => s.Id == Content.CategoryId);
            Category = category;
            _catCombo.Value = Category.Name;
            _catCombo.SelectedOption = Category;
            await _getSubCategories();
        }
        else if (Content.CategoryId != 0)
        {
            category = _categories.FirstOrDefault(s => s.Id == Content.CategoryId);
            Category = category;
            _catCombo.Value = Category.Name;
            _catCombo.SelectedOption = Category;
            await _getSubCategories();
        }

        StateHasChanged();
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        Content.ClientId = Client.Id;
        Content.TypeId = Type.Id;
        Content.StateId = State.Id;
        Content.CategoryId = Category.Id;
        Content.SubCategoryId = SubCategory.Id;

        var dto = _mapper.Map<OfferDto>(Content);
        dto.Client = null;
        OfferDto updated;

        if (_isNew)
            updated = await _dataProvider.Offers.Add(dto);

        else
            updated = await _dataProvider.Offers.Update(dto);

        Content = _mapper.Map<OfferVM>(updated);

        await OnSave.InvokeAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    private async Task _onResultChanged((string Value, string Text) resultOption)
    {
        SelectedResult = resultOption;
        await OnResultChanged.InvokeAsync(resultOption);
    }

    public OfferVM GetOffer()
    {
        Content.TypeId = Type.Id;
        Content.StateId = State.Id;
        Content.CategoryId = Category.Id;
        Content.SubCategoryId = SubCategory.Id;

        return Content;
    }

    #region Validation
    private bool validCode = true;
    private bool validClient = true;
    private bool validType = true;
    private bool validState = true;
    private bool validDate = true;
    private bool validPudgetPrice = true;
    private bool validOfferPrice = true;
    private bool validCategory = true;
    private bool validSubCategory = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validCode = !string.IsNullOrEmpty(Content.Code);
            validClient = Client != null && Client.Id != 0;
            validType = Type != null && Type.Id != 0;
            validState = State != null && State.Id != 0;
            validDate = Content.Date == null ? false : ((DateTime)Content.Date) >= DateTime.Now;
            validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
            validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;
            validCategory = Category != null && Category.Id != 0;
            validSubCategory = SubCategory != null && SubCategory.Id != 0;

            return validCode && validClient && validType && validState && validDate && validPudgetPrice && validOfferPrice && validCategory && validSubCategory;
        }
        else
        {
            validCode = true;
            validClient = true;
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
                case "Lead":
                    validClient = Client != null && Client.Id != 0;
                    return validClient;
                case "Type":
                    validType = Type != null && Type.Id != 0;
                    return validType;
                case "State":
                    validState = State != null && State.Id != 0;
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
                    validCategory = Category != null && Category.Id != 0;
                    return validCategory;
                case "SubCategory":
                    validSubCategory = SubCategory != null && SubCategory.Id != 0;
                    return validSubCategory;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();
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

    public ClientVM _client = new ClientVM();
    public ClientVM Client
    {
        get => _client;
        set
        {
            if (_client == value || value == null) return;
            _client = value;
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

    private async Task _onCategoryChanged(ProjectCategoryVM category)
    {
        Category = category;
        await _getSubCategories();
    }

    private async Task _onClientChanged(ClientVM client)
    {
        Client = client;
    }

    private async Task _getRecords()
    {
        await _getClients();
        await _getTypes();
        await _getStates();
        await _getCategories();
    }

    private async Task _getClients()
    {
        var dtos = await _dataProvider.Clients.GetAll();
        var vms = _mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);
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

    private async Task _getSubCategories()
    {
        if (_category == null) return;
        var dtos = await _dataProvider.ProjectsSubCategories.GetAll(_category.Id);
        var vms = _mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _subCategories.Clear();
        vms.ForEach(_subCategories.Add);

        StateHasChanged();

        // SubCategory
        if (Content.SubCategory != null)
        {
            var subCategoryDto = Mapping.Mapper.Map<ProjectSubCategoryDto>(Content.SubCategory);
            SubCategory = _mapper.Map<ProjectSubCategoryVM>(subCategoryDto);
            _subCatCombo.Value = SubCategory.Name;
            _subCatCombo.SelectedOption = SubCategory;
        }
        else if (Content.SubCategoryId != 0)
        {
            SubCategory = _subCategories.FirstOrDefault(s => s.Id == Content.SubCategoryId);
            _subCatCombo.Value = SubCategory.Name;
            _subCatCombo.SelectedOption = SubCategory;
        }

        StateHasChanged();
    }
    #endregion
}