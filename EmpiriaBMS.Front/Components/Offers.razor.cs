using BlazorBootstrap;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Fast.Components.FluentUI.Utilities;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace EmpiriaBMS.Front.Components;

public partial class Offers
{
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<OfferStateVM> _offerStates = new ObservableCollection<OfferStateVM>();
    private ObservableCollection<OfferTypeVM> _offerTypes = new ObservableCollection<OfferTypeVM>();

    private OfferStateVM _selectedOfferState;
    public OfferStateVM SelectedOfferState
    {
        get => _selectedOfferState;
        set
        {
            if (_selectedOfferState != value)
            {
                _selectedOfferState = value;
                _selectedOffer = null;
                _getOffers(_selectedOfferState.Id, SelectedOfferType.Id, refresh: true);
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
                _selectedOffer = null;
                _getOffers(_selectedOfferState.Id, SelectedOfferType.Id, refresh: true);
            }
        }
    }

    private OfferVM _selectedOffer;

    // On Add/Edit Offer Dialog
    private FluentDialog _dialog;
    private bool _isDialogOdepened = false;

    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var runInTeams = await MicrosoftTeams.IsInTeams();

            await Refresh();
        }
    }

    private async Task _getOfferStates()
    {
        var dtos = await _dataProvider.OfferStates.GetAll();
        var vms = Mapper.Map<List<OfferStateVM>>(dtos);
        _offerStates.Clear();
        vms.ForEach(_offerStates.Add);
    }

    private async Task _getOfferTypes()
    {
        var dtos = await _dataProvider.OfferTypes.GetAll();
        var vms = Mapper.Map<List<OfferTypeVM>>(dtos);
        _offerTypes.Clear();
        vms.ForEach(_offerTypes.Add);
    }

    private async Task _getOffers(int stateId = 0, int typeId = 0, bool refresh = false)
    {
        var dtos = await _dataProvider.Offers.GetAll(stateId, typeId);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);
        if (refresh)
            StateHasChanged();
    }

    private async Task Refresh()
    {
        await _getOfferStates();
        await _getOfferTypes();
        _selectedOfferState = _offerStates.FirstOrDefault();
        _selectedOfferType = _offerTypes.FirstOrDefault();
        await _getOffers(_selectedOfferState.Id, _selectedOfferType.Id);
        StateHasChanged();
    }

    #region Dialogs Functions
    private void CloseDialogClick()
    {
        if (_isDialogOdepened)
        {
            _dialog.Hide();
            _isDialogOdepened = false;
        }
    }

    private async Task SaveDialogClick()
    {
        if (_isDialogOdepened)
        {
            _dialog.Hide();
            _isDialogOdepened = false;

            await Refresh();
        }
    }

    private void AddOffer(MouseEventArgs e)
    {
        _selectedOffer = null;
        _selectedOffer = new OfferVM();
        _dialog.Show();
        _isDialogOdepened = true;
    }

    private void EditOffer(MouseEventArgs e)
    {
        _dialog.Show();
        _isDialogOdepened = true;
    }

    private void DeleteOffer(MouseEventArgs e)
    {
        if (_selectedOffer != null)
        {
            _deleteDialog.Show();
            _isDeleteDialogOdepened = true;
        } 
    }
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            if (_selectedOffer != null)
                await _dataProvider.Offers.Delete(_selectedOffer.Id);

            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;

            await _getOffers(SelectedOfferState.Id, SelectedOfferType.Id, true);
        }
    }

    private void OnDeleteClose()
    {
        if (_isDeleteDialogOdepened)
        {
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;
        }
    }
    #endregion
}
