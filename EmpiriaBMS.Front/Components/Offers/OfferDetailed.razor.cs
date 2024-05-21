using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
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
            else
                SelectedOfferState = null;

            if (value.TypeId != 0)
                SelectedOfferType = Types.FirstOrDefault(s => s.Id == value.TypeId);
            else
                SelectedOfferType = null;

            if (value.ResultId != 0)
                SelectedOfferResult = Results.FirstOrDefault(s => s.Id == value.ResultId);
            else
                SelectedOfferResult = null;

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

    private OfferStateVM _selectedOfferState;
    public OfferStateVM SelectedOfferState
    {
        get => _selectedOfferState;
        set
        {
            if (_selectedOfferState != value)
            {
                _selectedOfferState = value;
                if (Offer != null && value != null && value.Id != Offer?.StateId)
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
                if (Offer != null && value != null && value.Id != Offer?.TypeId)
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
                if (Offer != null && value != null && value.Id != Offer?.ResultId)
                    Offer.ResultId = SelectedOfferResult.Id;
            }
        }
    }

    public async Task Save()
    {
        var valid = Validate();
        if (!valid) return;

        var dto = Mapper.Map<OfferDto>(Offer);
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
    private bool validResult = true;
    private bool validPudgetPrice = true;
    private bool validOfferPrice = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validCode = !string.IsNullOrEmpty(Offer.Code);
            validType = Offer.TypeId != 0;
            validState = Offer.StateId != 0;
            validDate = Offer.Date == null ? false : ((DateTime)Offer.Date) >= DateTime.Now;
            validResult = Offer.ResultId != 0;
            validPudgetPrice = Offer.PudgetPrice != 0 && Offer.PudgetPrice != null;
            validOfferPrice = Offer.OfferPrice != 0 && Offer.OfferPrice != null;

            return validCode && validType && validState && validResult && validDate && validPudgetPrice && validOfferPrice;
        }
        else
        {
            validCode = true;
            validType = true;
            validState = true;
            validResult = true;
            validDate = true;
            validPudgetPrice = true;
            validOfferPrice = true;

            switch (fieldname)
            {
                case "Code":
                    validCode = !string.IsNullOrEmpty(Offer.Code);
                    return validCode;
                case "Type":
                    validType = Offer.TypeId != 0;
                    return validType;
                case "State":
                    validState = Offer.StateId != 0;
                    return validState;
                case "Result":
                    validResult = Offer.ResultId != 0;
                    return validResult;
                case "Date":
                    validDate = Offer.Date == null ? false : ((DateTime)Offer.Date) >= DateTime.Now;
                    return validDate;
                case "PudgetPrice":
                    validPudgetPrice = Offer.PudgetPrice != 0 && Offer.PudgetPrice != null;
                    return validPudgetPrice;
                case "OfferPrice":
                    validOfferPrice = Offer.OfferPrice != 0 && Offer.OfferPrice != null;
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
        validResult = true;
        validDate = true;
        validPudgetPrice = true;
        validOfferPrice = true;
    }
    #endregion
}
