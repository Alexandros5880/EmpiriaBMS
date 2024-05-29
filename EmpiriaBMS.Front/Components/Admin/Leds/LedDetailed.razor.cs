using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class LedDetailed
{
    [Parameter]
    public LedVM Content { get; set; } = default!;

    [Parameter]
    public FluentDialog Dialog { get; set; } = null;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair(LedVM record = null)
    {
        if (record != null)
            Content = record;

        if (record == null)
            Content = new LedVM()
            {
                ExpectedDurationDate = DateTime.Now.AddMonths(1),
            };

        await _getRecords();

        StateHasChanged();
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        if (Content is not null)
        {
            Content.Offer = null;
            Content.Client = null;
            Content.Address = null;

            var dto = _mapper.Map<LedDto>(Content);
            // Save Led
            if (await _dataProvider.Leds.Any(p => p.Id == Content.Id))
            {
                var updated = await _dataProvider.Leds.Update(dto);
                Content = _mapper.Map<LedVM>(updated);
            }
            else
            {
                var updated = await _dataProvider.Leds.Add(dto);
                Content = _mapper.Map<LedVM>(updated);
            }
        }
    }

    #region Validation
    private bool validName = true;
    private bool validClient = true;
    private bool validPotencialFee = true;
    private bool validOffer = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);
            validClient = !string.IsNullOrEmpty(Content?.Client?.FullName) || Content.ClientId != 0;
            validPotencialFee = Content?.PotencialFee > 0;
            validOffer = !string.IsNullOrEmpty(Content?.Offer?.Code) || (Content.OfferId != 0 && Content.OfferId != null);

            return validName && validClient && validPotencialFee && validOffer;
        }
        else
        {
            validName = true;
            validClient = true;
            validPotencialFee = true;
            validOffer = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                case "Client":
                    validClient = !string.IsNullOrEmpty(Content?.Client?.FullName) || Content.ClientId != 0;
                    return validClient;
                case "validPotencialFee":
                    validClient = validPotencialFee = Content?.PotencialFee > 0; ;
                    return validPotencialFee;
                case "Offer":
                    validOffer = !string.IsNullOrEmpty(Content?.Offer?.Code) || Content.OfferId != 0;
                    return validOffer;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records

    // Client Selection
    ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();

    private ClientVM _client = new ClientVM();
    public ClientVM Client
    {
        get => _client;
        set
        {
            if (_client == value || value == null) return;
            _client = value;
            Content.ClientId = _client.Id;
            //Content.Client = _client;
        }
    }

    // Offer Selection
    ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();

    private OfferVM _offer = new OfferVM();
    public OfferVM Offer
    {
        get => _offer;
        set
        {
            if (_offer == value || value == null) return;
            _offer = value;
            Content.OfferId = _offer.Id;
            //Content.Offer = _offer;
        }
    }

    // Result Selection
    private List<(string Value, string Text)> _results = Enum.GetValues(typeof(LedResult))
                                                             .Cast<LedResult>()
                                                             .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                                .First()
                                                                .GetCustomAttribute<DisplayAttribute>()?
                                                                .GetName() ?? e.ToString()))
                                                             .ToList();

    private (string Value, string Text) _selectedResult;
    public (string Value, string Text) SelectedResult
    {
        get => _selectedResult;
        set
        {
            _selectedResult = value;
            LedResult result = (LedResult)Enum.Parse(typeof(LedResult), value.Value);
            Content.Result = result;
        }
    }


    private async Task _getRecords()
    {
        await _getClients();
        await _getOffers();
    }

    private async Task _getClients()
    {
        var dtos = await _dataProvider.Clients.GetAll();
        var vms = _mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);

        Client = _clients.FirstOrDefault(c => c.Id == Content.ClientId) ?? null;
    }

    private async Task _getOffers()
    {
        var dtos = await _dataProvider.Offers.GetAll();
        var vms = _mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);

        Offer = _offers.FirstOrDefault(c => c.Id == Content.OfferId) ?? null;
    }
    #endregion

    #region Map Address
    private Map _map;

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Content.Address = address;
    }
    #endregion
}
