using BlazorBootstrap;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Dtos.KPIS;
using EmpiriaBMS.Front.Components.Admin.Projects.Clients;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Fast.Components.FluentUI.Utilities;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class Offers
{
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

    private OfferStateVM _selectedOfferState;
    private OfferTypeVM _selectedOfferType;
    private (string Value, string Text) _selectedOfferResult;
    private ProjectVM _selectedProject;
    private OfferVM _selectedOffer;

    #region Data Grid
    IQueryable<OfferVM> FilteredItems => _offers?.AsQueryable();
    PaginationState pagination = new PaginationState { ItemsPerPage = 4 };
    private string _projectNameFilter = string.Empty;
    private string _clientNameFilter = string.Empty;

    private void HandleProjectNameFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _projectNameFilter = value;
        }
        else if (string.IsNullOrWhiteSpace(_projectNameFilter) || string.IsNullOrEmpty(_projectNameFilter))
        {
            _projectNameFilter = string.Empty;
        }
    }

    private void HandleClientNameFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _clientNameFilter = value;
        }
        else if (string.IsNullOrWhiteSpace(_clientNameFilter) || string.IsNullOrEmpty(_clientNameFilter))
        {
            _clientNameFilter = string.Empty;
        }
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var runInTeams = await MicrosoftTeams.IsInTeams();

            await Refresh();
        }
    }

    #region Get Records
    private async Task _getOfferStates()
    {
        var dtos = await _dataProvider.OfferStates.GetAll();
        var vms = Mapper.Map<List<OfferStateVM>>(dtos);
        _offerStates.Clear();
        _offerStates.Add(new OfferStateVM { Id = 0, Name = "Select State..." });
        vms.ForEach(_offerStates.Add);
    }

    private async Task _getOfferTypes()
    {
        var dtos = await _dataProvider.OfferTypes.GetAll();
        var vms = Mapper.Map<List<OfferTypeVM>>(dtos);
        _offerTypes.Clear();
        _offerTypes.Add(new OfferTypeVM { Id = 0, Name = "Select Type..." });
        vms.ForEach(_offerTypes.Add);
    }

    private async Task _getAllProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = Mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        _projects.Add(new ProjectVM { Id = 0, Name = "Select Project..." });
        vms.ForEach(_projects.Add);
    }

    private async Task _getOffers(int projectId, int stateId = 0, int typeId = 0, OfferResult? result = null, bool refresh = false)
    {
        var dtos = await _dataProvider.Offers.GetAll(projectId, stateId, typeId, result);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);
        if (refresh)
            StateHasChanged();
    }
    #endregion

    private async Task Refresh()
    {
        await _getAllProjects();
        await _getOfferStates();
        await _getOfferTypes();
        _selectedProject = _projects.FirstOrDefault(o => o.Name.Equals("Select Project..."));
        _selectedOfferState = _offerStates.FirstOrDefault(o => o.Name.Equals("Select State..."));
        _selectedOfferType = _offerTypes.FirstOrDefault(o => o.Name.Equals("Select Type..."));
        _selectedOfferResult = OfferResult.SUCCESSFUL.ToTuple();
        OfferResult e;
        Enum.TryParse(_selectedOfferResult.Value, out e);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, e, refresh: true);
        StateHasChanged();
    }

    #region On Filters Event Changed
    private async Task _onProjectSelectionChanged(ProjectVM project)
    {
        _selectedProject = project;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, result, refresh: true);
    }

    private async Task _onStateSelectionChanged(OfferStateVM state)
    {
        _selectedOfferState = state;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, result, refresh: true);
    }

    private async Task _onTypeSelectionChanged(OfferTypeVM type)
    {
        _selectedOfferType = type;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, result, refresh: true);
    }

    private async Task _onResultSelectionChanged((string Value, string Text) result)
    {
        _selectedOfferResult = result;
        OfferResult e;
        Enum.TryParse(result.Value, out e);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, e, refresh: true);
    }
    #endregion

    #region Dialogs Functions
    private async Task _add(MouseEventArgs e)
    {
        _selectedOffer = new OfferVM()
        {
            Date = DateTime.Now
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
            Width = "min(80%, 1000px);"
        };
        
        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferCreationDialog>(_selectedOffer, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            //OfferVM vm = result.Data as OfferVM;
            //var dto = Mapper.Map<OfferDto>(vm);

            await Refresh();
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
            Width = "min(80%, 1000px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferCreationDialog>(_selectedOffer, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            //OfferVM vm = result.Data as OfferVM;
            //var dto = Mapper.Map<OfferDto>(vm);

            await Refresh();
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
            await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, or, true);
        }

        await dialog.CloseAsync();
    }
    #endregion
}
