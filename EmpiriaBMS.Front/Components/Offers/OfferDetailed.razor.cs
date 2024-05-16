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
    private OfferVM _offer;
    [Parameter]
    public OfferVM Offer
    {
        get => _offer;
        set {
            if (value.StateId != 0)
                SelectedOfferState = States.FirstOrDefault(s => s.Id == value.StateId);

            if (value.TypeId != 0)
                SelectedOfferType = Types.FirstOrDefault(s => s.Id == value.TypeId);

            if (value.ResultId != 0)
                SelectedOfferResult = Results.FirstOrDefault(s => s.Id == value.ResultId);

            _offer = value;
            _isNew = _offer.Id == 0;
        }
    }

    [Parameter]
    public ICollection<OfferTypeVM> Types { get; set; }

    [Parameter]
    public ICollection<OfferStateVM> States { get; set; }

    [Parameter]
    public ICollection<OfferResultVM> Results { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public bool DisplayTitle { get; set; } = true;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    private bool _isNew = true;
    private OfferValidator _validator = new OfferValidator();

    private OfferStateVM _selectedOfferState;
    public OfferStateVM SelectedOfferState
    {
        get => _selectedOfferState;
        set
        {
            if (_selectedOfferState != value)
            {
                _selectedOfferState = value;
                if (Offer != null && value.Id != Offer?.StateId)
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
                if (Offer != null && value.Id != Offer?.TypeId)
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
                if (Offer != null && value.Id != Offer?.ResultId)
                    Offer.ResultId = SelectedOfferResult.Id;
            }
        }
    }

    public async Task Save()
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

    public bool Validate() => _validator.Validate(Offer);
}
