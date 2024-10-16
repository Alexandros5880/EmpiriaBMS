﻿using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Home.Offers;

public partial class Offers
{
    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    private bool _loading = false;

    private FluentCombobox<(string Value, string Text)> resultFilterCombo;
    private FluentCombobox<ClientVM> clientFilterCombo;
    private FluentCombobox<ProjectVM> projectFilterCombo;
    private FluentCombobox<OfferStateVM> stateFilterCombo;
    private FluentCombobox<OfferTypeVM> typeFilterCombo;

    private ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<OfferStateVM> _offerStates = new ObservableCollection<OfferStateVM>();
    private ObservableCollection<OfferTypeVM> _offerTypes = new ObservableCollection<OfferTypeVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();

    private List<(string Value, string Text)> _offerResults = Enum.GetValues(typeof(OfferResult))
                                                                  .Cast<OfferResult>()
                                                                  .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                                      .First()
                                                                      .GetCustomAttribute<DisplayAttribute>()?
                                                                      .GetName() ?? e.ToString()))
                                                                  .ToList();

    private ClientVM _selectedClient;
    private OfferStateVM _selectedOfferState;
    private OfferTypeVM _selectedOfferType;
    private (string Value, string Text) _selectedOfferResult;
    private string _selectedResultValue;
    private ProjectVM _selectedProject;
    private OfferVM _selectedOffer;

    #region Data Grid
    IQueryable<OfferVM> FilteredItems => _offers?.AsQueryable();
    PaginationState pagination = new PaginationState { ItemsPerPage = 6 };

    private async Task HandleResultChange(OfferVM context, ChangeEventArgs e)
    {
        if (Enum.TryParse<OfferResult>(e.Value.ToString(), out var newResult))
        {
            context.Result = newResult;
            var dto = Mapper.Map<OfferDto>(context);
            await _dataProvider.Offers.Update(dto);
            await Refresh();
        }
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (_loading == false)
            {
                _loading = true;
                StateHasChanged();
            }

            var runInTeams = await MicrosoftTeams.IsInTeams();

            await Refresh();

            if (_loading == true)
            {
                _loading = false;
                StateHasChanged();
            }
        }
    }

    #region Get Records
    private async Task _getClients()
    {
        var dtos = await _dataProvider.Clients.GetAll();
        var vms = Mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);
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

    private async Task _getAllProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = Mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        vms.ForEach(_projects.Add);
    }

    private async Task _getOffers(long? projectId, long? stateId = 0, long? typeId = 0, long? clientId = 0, OfferResult? result = null, bool refresh = false)
    {
        var dtos = await _dataProvider.Offers.GetAll(projectId: projectId, stateId: stateId, typeId: typeId, clientId: clientId, result: result);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);
        if (refresh)
            StateHasChanged();
    }
    #endregion

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        await _getClients();
        await _getAllProjects();
        await _getOfferStates();
        await _getOfferTypes();

        _selectedOfferResult = OfferResult.SUCCESSFUL.ToTuple();
        SetSelectedOption(_selectedOfferResult.Value);
        OfferResult e;
        Enum.TryParse(_selectedOfferResult.Value, out e);
        await _getOffers(_selectedProject?.Id, _selectedOfferState?.Id, _selectedOfferType?.Id, _selectedClient?.Id ?? 0, e, refresh: true);

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task SetClientFilter(ClientVM client)
    {
        await _getClients();
        _selectedClient = _clients?.FirstOrDefault(l => l.Id == client.Id);
        clientFilterCombo.Value = _selectedClient.Name;
        StateHasChanged();
    }

    public async Task SetResultFilter(OfferResult result)
    {
        _selectedOfferResult = result.ToTuple();
        OfferResult e;
        Enum.TryParse(_selectedOfferResult.Value, out e);
        await _getOffers(_selectedProject?.Id, _selectedOfferState?.Id, _selectedOfferType?.Id, _selectedClient?.Id ?? 0, e, refresh: true);
        SetSelectedOption(_selectedOfferResult.Value);
    }

    public void SetSelectedOption(string value)
    {
        var selectedOption = _offerResults.FirstOrDefault(item => item.Value == value);
        if (selectedOption != default)
        {
            _selectedResultValue = selectedOption.Value;
        }
    }

    #region On Filters Event Changed
    private async Task _onClientSelectionChanged(ClientVM client)
    {
        _selectedClient = client;
        await Search();
    }  

    private async Task _onProjectSelectionChanged(ProjectVM project)
    {
        _selectedProject = project;
        await Search();
    }

    private async Task _onStateSelectionChanged(OfferStateVM state)
    {
        _selectedOfferState = state;
        await Search();
    }

    private async Task _onTypeSelectionChanged(OfferTypeVM type)
    {
        _selectedOfferType = type;
        await Search();
    }

    private async Task _onResultSelectionChanged((string Value, string Text) result)
    {
        _selectedOfferResult = result;
        await Search();
    }

    public async Task Search()
    {
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject?.Id, _selectedOfferState?.Id, _selectedOfferType?.Id, _selectedClient?.Id ?? 0, result, refresh: true);
    }
    #endregion

    #region Dialogs Functions
    private async Task _add(MouseEventArgs e)
    {
        var clientDto = Mapper.Map<ClientDto>(_selectedClient);
        var client = Mapping.Mapper.Map<Client>(clientDto);

        _selectedOffer = new OfferVM()
        {
            Client = client,
            ClientId = client?.Id,
            Result = OfferResult.WAITING
        };

        DialogParameters parameters = new()
        {
            Title = $"New Offer",
            PrimaryActionEnabled = false,
            SecondaryActionEnabled = false,
            PrimaryAction = null,
            SecondaryAction = null,
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(max(50vw, 500px), 1000px)",
            Height = "min(max(80vh, 500px), 1000px)"
        };

        _selectedOffer.ClientId = _selectedClient?.Id;

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferCreationDialog>(_selectedOffer, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            _selectedProject = null;
            _selectedOfferState = null;
            _selectedOfferType = null;

            OfferVM offerVMData = result.Data as OfferVM;

            // Update Client Filter With New Offers Client
            var clientId = offerVMData.ClientId;
            await _getClients();
            _selectedClient = _clients?.FirstOrDefault(l => l.Id == clientId);
            clientFilterCombo.Value = _selectedClient.Name;

            // Update Result Filter To Waiting
            await SetResultFilter(offerVMData.Result);

            OfferResult offerResult;
            Enum.TryParse(_selectedOfferResult.Value, out offerResult);

            await _getOffers(_selectedProject?.Id,
                _selectedOfferState?.Id, 
                _selectedOfferType?.Id, 
                _selectedClient?.Id ?? 0, 
                offerResult, 
                refresh: true);

            StateHasChanged();
        }
    }

    private async Task _edit(OfferVM offer)
    {
        _selectedOffer = offer;

        DialogParameters parameters = new()
        {
            Title = $"Edit Offer {_selectedOffer.Code}",
            PrimaryActionEnabled = false,
            SecondaryActionEnabled = false,
            PrimaryAction = null,
            SecondaryAction = null,
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(max(50vw, 500px), 1000px)",
            Height = "min(max(80vh, 500px), 1000px)"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferCreationDialog>(_selectedOffer, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            OfferVM vm = result.Data as OfferVM;

            // Update Result Filter To Waiting
            var waitingResult = vm.Result.ToTuple();
            SetSelectedOption(waitingResult.Value);
            StateHasChanged();
            _onResultSelectionChanged(waitingResult);
            await Search();
        }
    }

    private async Task _delete(OfferVM offer)
    {
        _selectedOffer = offer;

        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the offer {_selectedOffer.Code}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await _dataProvider.Offers.Delete(_selectedOffer.Id);
            OfferResult or;
            Enum.TryParse(_selectedOfferResult.Value, out or);
            await _getOffers(_selectedProject?.Id, _selectedOfferState?.Id, _selectedOfferType?.Id, _selectedClient?.Id ?? 0, or, true);
        }

        await dialog.CloseAsync();
    }
    #endregion

    #region Export Functions
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var data = FilteredItems.Select(c => new OfferExport(c)).ToList();
        var fileName = $"Offers-{date.ToEuropeFormat()}.csv";
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
