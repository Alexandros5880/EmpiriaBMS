using BlazorBootstrap;
using EmpiriaBMS.Core.Dtos.KPIS;
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

namespace EmpiriaBMS.Front.Components.Offers;

public partial class Offers
{
    private ObservableCollection<OfferVM> _offers = new ObservableCollection<OfferVM>();
    private ObservableCollection<OfferStateVM> _offerStates = new ObservableCollection<OfferStateVM>();
    private ObservableCollection<OfferTypeVM> _offerTypes = new ObservableCollection<OfferTypeVM>();
    private ObservableCollection<OfferResultVM> _offerResults = new ObservableCollection<OfferResultVM>();
    private ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();

    private OfferStateVM _selectedOfferState;
    private OfferTypeVM _selectedOfferType;
    private OfferResultVM _selectedOfferResult;
    private ProjectVM _selectedProject;
    private OfferVM _selectedOffer;

    // On Add/Edit Offer Dialog
    private FluentDialog _dialog;
    private bool _isDialogOdepened = false;

    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;

    #region Data Grid
    IQueryable<OfferVM> FilteredItems => _offers?.AsQueryable().Where(x => x.Project.Name.Contains(_projectNameFilter, StringComparison.CurrentCultureIgnoreCase)
                                                                            && (x.Project.Client == null ? true : x.Project.Client.FullName.Contains(_clientNameFilter, StringComparison.CurrentCultureIgnoreCase)));
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

    private OfferDetailedLand _offersDetailedLandRef;

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

    private async Task _getOfferResults()
    {
        var dtos = await _dataProvider.OfferResult.GetAll();
        var vms = Mapper.Map<List<OfferResultVM>>(dtos);
        _offerResults.Clear();
        _offerResults.Add(new OfferResultVM { Id = 0, Name = "Select Result..." });
        vms.ForEach(_offerResults.Add);
    }

    private async Task _getAllProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = Mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        _projects.Add(new ProjectVM { Id = 0, Name = "Select Project..." });
        vms.ForEach(_projects.Add);
    }

    private async Task _getOffers(int projectId, int stateId = 0, int typeId = 0, int resultId = 0, bool refresh = false)
    {
        var dtos = await _dataProvider.Offers.GetAll(projectId, stateId, typeId, resultId);
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
        await _getOfferResults();
        _selectedProject = _projects.FirstOrDefault(o => o.Name.Equals("Select Project..."));
        _selectedOfferState = _offerStates.FirstOrDefault(o => o.Name.Equals("Select State..."));
        _selectedOfferType = _offerTypes.FirstOrDefault(o => o.Name.Equals("Select Type..."));
        _selectedOfferResult = _offerResults.FirstOrDefault(o => o.Name.Equals("Select Result..."));
        await _getOffers(_selectedOfferState.Id, _selectedOfferType.Id);
        StateHasChanged();
    }

    #region On Filters Event Changed
    private async Task _onProjectSelectionChanged(ProjectVM project)
    {
        _selectedProject = project;
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedOfferResult.Id, refresh: true);
    }

    private async Task _onStateSelectionChanged(OfferStateVM state)
    {
        _selectedOfferState = state;
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedOfferResult.Id, refresh: true);
    }

    private async Task _onTypeSelectionChanged(OfferTypeVM type)
    {
        _selectedOfferType = type;
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedOfferResult.Id, refresh: true);
    }

    private async Task _onResultSelectionChanged(OfferResultVM result)
    {
        _selectedOfferResult = result;
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedOfferResult.Id, refresh: true);
    }
    #endregion

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

    private async Task AddOffer(MouseEventArgs e)
    {
        _selectedOffer = new OfferVM();
        StateHasChanged();
        _dialog.Show();
        _isDialogOdepened = true;
    }

    private void _edit(OfferVM offer)
    {
        _selectedOffer = offer;
        StateHasChanged();
        if (_selectedOffer != null && _selectedOffer.Id != 0)
        {
            _dialog.Show();
            _isDialogOdepened = true;
        }
    }

    private void _delete(OfferVM offer)
    {
        _selectedOffer = offer;
        if (_selectedOffer != null && _selectedOffer.Id != 0)
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

            await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedOfferResult.Id, true);
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
