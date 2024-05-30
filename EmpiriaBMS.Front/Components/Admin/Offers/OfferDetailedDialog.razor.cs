using CsvHelper;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
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
                    validDate = Content.Date == null ? false : ((DateTime)Content.Date) >= DateTime.Now;
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
    #endregion

    #region Get Related Records
    ObservableCollection<OfferTypeVM> _types = new ObservableCollection<OfferTypeVM>();
    ObservableCollection<OfferStateVM> _states = new ObservableCollection<OfferStateVM>();
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