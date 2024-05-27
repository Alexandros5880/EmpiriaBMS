using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailed
{
    [Parameter]
    public OfferVM Content { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    private bool _isNew => Content.Id == 0;

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

        if (Content?.State != null)
        {
            State = _states.FirstOrDefault(s => s.Id == Content.StateId);
        }

        if (Content?.Type != null)
        {
            Type = _types.FirstOrDefault(s => s.Id == Content.TypeId);
        }

        if (Content.Result != null)
        {
            SelectedResult = _results.FirstOrDefault(r => r.Value == Content.Result.ToString());
        }

        StateHasChanged();
    }

    public async Task Save()
    {
        var valid = Validate();
        if (!valid) return;

        var dto = Mapper.Map<OfferDto>(Content);
        OfferDto updated;

        if (_isNew)
            updated = await _dataProvider.Offers.Add(dto);

        else
            updated = await _dataProvider.Offers.Update(dto);

        await OnSave.InvokeAsync();
    }

    #region Validation
    private bool validCode = true;
    private bool validType = true;
    private bool validState = true;
    private bool validDate = true;
    private bool validPudgetPrice = true;
    private bool validOfferPrice = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validCode = !string.IsNullOrEmpty(Content.Code);
            validType = Content.TypeId != 0;
            validState = Content.StateId != 0;
            validDate = Content.Date != null;
            validPudgetPrice = Content.PudgetPrice != 0 && Content.PudgetPrice != null;
            validOfferPrice = Content.OfferPrice != 0 && Content.OfferPrice != null;

            return validCode && validType && validState && validDate && validPudgetPrice && validOfferPrice;
        }
        else
        {
            validCode = true;
            validType = true;
            validState = true;
            validDate = true;
            validPudgetPrice = true;
            validOfferPrice = true;

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
                    validDate = Content.Date != null;
                    return validDate;
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

    public void ResetValidation()
    {
        validCode = true;
        validType = true;
        validState = true;
        validDate = true;
        validPudgetPrice = true;
        validOfferPrice = true;
    }
    #endregion

    #region Get Related Records
    ObservableCollection<OfferStateVM> _states = new ObservableCollection<OfferStateVM>();
    ObservableCollection<OfferTypeVM> _types = new ObservableCollection<OfferTypeVM>();
    private List<(string Value, string Text)> _results = Enum.GetValues(typeof(OfferResult))
                                                         .Cast<OfferResult>()
                                                         .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                            .First()
                                                            .GetCustomAttribute<DisplayAttribute>()?
                                                            .GetName() ?? e.ToString()))
                                                         .ToList();

    private OfferStateVM _state = new OfferStateVM();
    public OfferStateVM State
    {
        get => _state;
        set
        {
            if (_state == value || value == null) return;
            _state = value;
            Content.StateId = _state.Id;
            var dto = Mapper.Map<OfferStateDto>(_state);
            Content.State = Mapping.Mapper.Map<OfferState>(dto);
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
            var dto = Mapper.Map<OfferTypeDto>(_type);
            Content.Type = Mapping.Mapper.Map<OfferType>(dto);
        }
    }

    private (string Value, string Text) SelectedResult;

    private async Task _getRecords()
    {
        await _getStates();
        await _getTypes();
    }

    private async Task _getStates()
    {
        var dtos = await _dataProvider.OfferStates.GetAll();
        var vms = Mapper.Map<List<OfferStateVM>>(dtos);
        _states.Clear();
        vms.ForEach(_states.Add);
    }

    private async Task _getTypes()
    {
        var dtos = await _dataProvider.OfferTypes.GetAll();
        var vms = Mapper.Map<List<OfferTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }
    #endregion
}
