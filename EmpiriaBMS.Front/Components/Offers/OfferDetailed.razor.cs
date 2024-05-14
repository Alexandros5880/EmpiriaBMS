using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Validation;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using System;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class OfferDetailed
{
    [Parameter]
    public OfferVM Offer { get; set; }

    [Parameter]
    public ICollection<OfferTypeVM> Types { get; set; }

    [Parameter]
    public ICollection<OfferStateVM> States { get; set; }

    [Parameter]
    public ICollection<OfferResultVM> Results { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public EventCallback OnCansel { get; set; }

    private bool _isNew = true;
    private OfferValidator _validator = new OfferValidator();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            
        }

        _isNew = Offer.Id == 0;
        StateHasChanged();
    }

    private OfferStateVM _selectedOfferState;
    public OfferStateVM SelectedOfferState
    {
        get => _selectedOfferState;
        set
        {
            if (_selectedOfferState != value)
            {
                _selectedOfferState = value;
                Offer.StateId = _selectedOfferState.Id;
            }
        }
    }

    private OfferTypeVM _selectedOfferType;
    public OfferTypeVM SelectedOfferType
    {
        get => _selectedOfferType;
        set
        {
            if (_selectedOfferType != value)
            {
                _selectedOfferType = value;
                Offer.TypeId = _selectedOfferType.Id;
            }
        }
    }

    private OfferResultVM _selectedOfferResult;
    public OfferResultVM SelectedOfferResult
    {
        get => _selectedOfferResult;
        set
        {
            if (_selectedOfferResult != value)
            {
                _selectedOfferResult = value;
                Offer.ResultId = SelectedOfferResult.Id;
            }
        }
    }

    private async Task Save()
    {
        var valid = _validator.Validate(Offer);
        if (!valid) return;

        var dto = Mapper.Map<OfferDto>(Offer);
        OfferDto updated;

        if (_isNew)
            updated = await _dataProvider.Offers.Add(dto);

        else
            updated = await _dataProvider.Offers.Update(dto);

        await OnSave.InvokeAsync();
    }
}
