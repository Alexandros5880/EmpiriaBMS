using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Fast.Components.FluentUI;
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
                _getOffers(refresh: true);
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
                _getOffers(refresh: true);
            }
        }
    }

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














    private async void AddOffer(MouseEventArgs e)
    {
        
    }

    private async void EditOffer(MouseEventArgs e)
    {

    }

    private async void DeleteOffer(MouseEventArgs e)
    {

    }

    private async void OpenOffer(MouseEventArgs e)
    {

    }

    private async void CloseOffer(MouseEventArgs e)
    {

    }
}
