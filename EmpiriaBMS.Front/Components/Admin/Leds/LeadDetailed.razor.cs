using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class LeadDetailed
{
    private FluentCombobox<ClientVM> _clientCombo;
    private FluentCombobox<(string Value, string Text)> _resultCombo;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    [Parameter]
    public LeadVM Content { get; set; } = new LeadVM()
    {
        ExpectedDurationDate = DateTime.Now.AddMonths(1),
        Result = LeadResult.UNSUCCESSFUL
    };

    [Parameter]
    public EventCallback<LeadVM> OnSave { get; set; }

    [Parameter]
    public EventCallback<(string Value, string Text)> OnResultChanged { get; set; }

    private bool _displayClientForm = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

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

    public async Task Prepair(LeadVM record = null, bool full = true)
    {
        if (record != null)
            Content = record;

        if (full)
            await _getRecords();

        if (Content.Client != null)
        {
            var clientDto = Mapping.Mapper.Map<ClientDto>(Content.Client);
            Client = _mapper.Map<ClientVM>(clientDto);
        }
        else if (Content.ClientId != 0)
        {
            Client = _clients.FirstOrDefault(c => c.Id == Content.ClientId);
        }

        if (Content.Result != null)
        {
            SelectedResult = _results.FirstOrDefault(r => r.Value == Content.Result.ToString());
            if (_resultCombo != null)
            {
                var value = SelectedResult.Value;
                _resultCombo.Value = SelectedResult.Value;
                _resultCombo.SelectedOption = SelectedResult;
            }
        }
        else
        {
            SelectedResult = _results.FirstOrDefault(r => r.Value == LeadResult.UNSUCCESSFUL.ToString());
            if (_resultCombo != null)
            {
                var value = SelectedResult.Value;
                _resultCombo.Value = SelectedResult.Value;
                _resultCombo.SelectedOption = SelectedResult;
            }
        }

        await RefreshMap();

        StateHasChanged();
    }

    public async Task<LeadVM> SaveAsync()
    {
        var valid = Validate();

        StateHasChanged();

        if (valid)
        {
            Content.ClientId = Client.Id;

            var dto = _mapper.Map<LeadDto>(Content);

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

            dto.Client = null;
            dto.Address = null;

            // Save Led
            if (await _dataProvider.Leads.Any(p => p.Id == Content.Id))
            {
                var updated = await _dataProvider.Leads.Update(dto);
                Content = _mapper.Map<LeadVM>(updated);
            }
            else
            {
                var updated = await _dataProvider.Leads.Add(dto);
                Content = _mapper.Map<LeadVM>(updated);
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

    public LeadVM GetLed()
    {
        Content.ClientId = Client.Id;
        return Content;
    }

    #region Validation
    private bool validName = true;
    private bool validClient = true;
    private bool validPotencialFee = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = Content.Name != null && Content.Name.Length > 0;
            validClient = !string.IsNullOrEmpty(Client?.FullName) || Client?.Id != 0;
            validPotencialFee = Content?.PotencialFee > 0;

            return validName && validClient && validPotencialFee;
        }
        else
        {
            validName = true;
            validClient = true;
            validPotencialFee = true;

            switch (fieldname)
            {
                case "Name":
                    validName = Content.Name != null && Content.Name.Length > 0;
                    return validName;
                case "Client":
                    validClient = !string.IsNullOrEmpty(Client?.FullName) || Client?.Id != 0;
                    return validClient;
                case "validPotencialFee":
                    validClient = validPotencialFee = Content?.PotencialFee > 0; ;
                    return validPotencialFee;
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
        }
    }

    // Result Selection
    private List<(string Value, string Text)> _results = Enum.GetValues(typeof(LeadResult))
                                                             .Cast<LeadResult>()
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
            LeadResult result = (LeadResult)Enum.Parse(typeof(LeadResult), value.Value);
            Content.Result = result;
        }
    }


    private async Task _getRecords()
    {
        await _getClients();
    }

    private async Task _getClients()
    {
        var dtos = await _dataProvider.Clients.GetAll();
        var vms = _mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);

        Client = _clients.FirstOrDefault(c => c.Id == Content.ClientId) ?? null;
    }
    #endregion

    #region Map Address
    private Map _map;

    public async Task RefreshMap()
    {
        if (Content.Address != null && _map != null)
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
