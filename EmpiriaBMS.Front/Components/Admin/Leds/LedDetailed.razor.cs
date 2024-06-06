using EmpiriaBMS.Core.Config;
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
    public bool DisplayActions { get; set; } = true;

    [Parameter]
    public LedVM Content { get; set; }

    [Parameter]
    public bool DisplayOffer { get; set; } = true;

    [Parameter]
    public EventCallback<LedVM> OnSave { get; set; }

    [Parameter]
    public EventCallback<(string Value, string Text)> OnResultChanged { get; set; }

    private bool _displayClientForm = false;

    private void _toogleClientForm(bool? display = null)
    {
        if (display == null)
            _displayClientForm = !_displayClientForm;
        else
            _displayClientForm = (bool)display;
        StateHasChanged();
    }

    private void _onNewClientSave(ClientVM client)
    {
        if (client != null)
        {
            _clients.Add(client);
            Client = client;
            _toogleClientForm(false);
        }
    }

    public async Task Prepair(LedVM record = null, bool full = true)
    {
        if (record == null || record.Id == 0)
        {
            Content = new LedVM()
            {
                ExpectedDurationDate = DateTime.Now.AddMonths(1),
                Result = LedResult.UNSUCCESSFUL
            };

        }
        else
        {
            Content = record;
        }

        if (full)
            await _getRecords();

        if (Content.Offer != null)
        {
            var offerDto = Mapping.Mapper.Map<OfferDto>(Content.Offer);
            Offer = _mapper.Map<OfferVM>(offerDto);
        }

        if (Content.Client != null)
        {
            var clientDto = Mapping.Mapper.Map<ClientDto>(Content.Client);
            Client = _mapper.Map<ClientVM>(clientDto);
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
            SelectedResult = _results.FirstOrDefault(r => r.Value == LedResult.UNSUCCESSFUL.ToString());
            if (_resultCombo != null)
            {
                _resultCombo.Value = SelectedResult.Value;
                _resultCombo.SelectedOption = SelectedResult;
            }
        }

        await RefreshMap();

        StateHasChanged();
    }

    public async Task<LedVM> SaveAsync()
    {
        var valid = Validate();

        StateHasChanged();

        if (valid)
        {
            var dto = _mapper.Map<LedDto>(Content);

            // Save Address
            // If Addres Then Save Address
            if (dto?.Address != null && !(await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
                var address = await _dataProvider.Address.Add(addressDto);
                dto.AddressId = address.Id;
            }
            else if (dto?.Address != null && (await _dataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var address = await _dataProvider.Address.GetByPlaceId(dto.Address.PlaceId);
                dto.AddressId = address.Id;
            }

            dto.Offer = null;
            dto.Client = null;
            dto.Address = null;

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

            await OnSave.InvokeAsync(Content);
            return Content;
        }
        else
        {
            await OnSave.InvokeAsync(null);
            return null;
        }
    }

    private async Task _onResultChanged((string Value, string Text) resultOption)
    {
        SelectedResult = resultOption;
        await OnResultChanged.InvokeAsync(resultOption);
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
            validName = Content.Name != null && Content.Name.Length > 0;
            validClient = !string.IsNullOrEmpty(Content?.Client?.FullName) || Content.ClientId != 0;
            validPotencialFee = Content?.PotencialFee > 0;
            validOffer = !DisplayOffer || (!string.IsNullOrEmpty(Content?.Offer?.Code) || (Content.OfferId != 0 && Content.OfferId != null));

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
                    validName = Content.Name != null && Content.Name.Length > 0;
                    return validName;
                case "Client":
                    validClient = !string.IsNullOrEmpty(Content?.Client?.FullName) || Content.ClientId != 0;
                    return validClient;
                case "validPotencialFee":
                    validClient = validPotencialFee = Content?.PotencialFee > 0; ;
                    return validPotencialFee;
                case "Offer":
                    validOffer = !DisplayOffer || (!string.IsNullOrEmpty(Content?.Offer?.Code) || (Content.OfferId != 0 && Content.OfferId != null));
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
            var dto = _mapper.Map<ClientDto>(_client);
            Content.Client = Mapping.Mapper.Map<Client>(dto);
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
            var dto = _mapper.Map<OfferDto>(_offer);
            Content.Offer = Mapping.Mapper.Map<Offer>(dto);
        }
    }

    // Result Selection
    private FluentCombobox<(string Value, string Text)> _resultCombo;
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

    public async Task RefreshMap()
    {
        if (Content.Address != null)
        {
            await _map.SetAddress(Content.Address);
        }
    }

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Content.Address = address;
    }
    #endregion
}
