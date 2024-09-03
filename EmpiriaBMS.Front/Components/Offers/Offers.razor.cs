using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using Humanizer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Offers;

public partial class Offers
{
    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    private FluentCombobox<LeadVM> leadFilterCombo;
    private FluentCombobox<(string Value, string Text)> resultFilterCombo;

    private ObservableCollection<LeadVM> _leads = new ObservableCollection<LeadVM>();
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

    private LeadVM _selectedLead;
    private OfferStateVM _selectedOfferState;
    private OfferTypeVM _selectedOfferType;
    private (string Value, string Text) _selectedOfferResult;
    private string _selectedResultValue;
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
            var runInTeams = await MicrosoftTeams.IsInTeams();

            await Refresh();
        }
    }

    #region Get Records
    private async Task _getLeads()
    {
        var dtos = await _dataProvider.Leads.GetAll();
        var vms = Mapper.Map<List<LeadVM>>(dtos);
        _leads.Clear();
        _leads.Add(new LeadVM { Id = 0, Name = "Select Lead..." });
        vms.ForEach(_leads.Add);
    }

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

    private async Task _getOffers(int projectId, int stateId = 0, int typeId = 0, int leadId = 0, OfferResult? result = null, bool refresh = false)
    {
        var dtos = await _dataProvider.Offers.GetAll(projectId: projectId, stateId: stateId, typeId: typeId, leadId: leadId, result: result);
        var vms = Mapper.Map<List<OfferVM>>(dtos);
        _offers.Clear();
        vms.ForEach(_offers.Add);
        if (refresh)
            StateHasChanged();
    }
    #endregion

    public async Task Refresh()
    {
        await _getLeads();
        await _getAllProjects();
        await _getOfferStates();
        await _getOfferTypes();
        _selectedProject = _projects.FirstOrDefault(o => o.Name.Equals("Select Project..."));
        _selectedOfferState = _offerStates.FirstOrDefault(o => o.Name.Equals("Select State..."));
        _selectedOfferType = _offerTypes.FirstOrDefault(o => o.Name.Equals("Select Type..."));

        _selectedLead = _leads?.OrderByDescending(l => l.LastUpdatedDate).FirstOrDefault(o => o.Name.Equals("Select Lead..."));
        leadFilterCombo.Value = _selectedLead.Name;

        _selectedOfferResult = OfferResult.SUCCESSFUL.ToTuple();
        resultFilterCombo.Value = _selectedOfferResult.Text;
        OfferResult e;
        Enum.TryParse(_selectedOfferResult.Value, out e);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, e, refresh: true);

        StateHasChanged();
    }

    public async Task SetLeadFilter(LeadVM lead)
    {
        await _getLeads();
        _selectedLead = _leads?.FirstOrDefault(l => l.Id == lead.Id);
        leadFilterCombo.Value = _selectedLead.Name;
        StateHasChanged();
    }

    public async Task SetResultFilter(OfferResult result)
    {
        _selectedOfferResult = result.ToTuple();
        OfferResult e;
        Enum.TryParse(_selectedOfferResult.Value, out e);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, e, refresh: true);
        resultFilterCombo.Value = _selectedOfferResult.Text;
        StateHasChanged();
    }

    #region On Filters Event Changed
    private async Task _onLeadSelectionChanged(LeadVM lead)
    {
        if (lead == null) return;

        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);

        _selectedLead = lead;
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead.Id, result, refresh: true);
    }

    private async Task _onProjectSelectionChanged(ProjectVM project)
    {
        if (project == null) return;

        _selectedProject = project;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, result, refresh: true);
    }

    private async Task _onStateSelectionChanged(OfferStateVM state)
    {
        _selectedOfferState = state;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, result, refresh: true);
    }

    private async Task _onTypeSelectionChanged(OfferTypeVM type)
    {
        _selectedOfferType = type;
        OfferResult result;
        Enum.TryParse(_selectedOfferResult.Value, out result);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, result, refresh: true);
    }

    private async Task _onResultSelectionChanged((string Value, string Text) result)
    {
        _selectedOfferResult = result;
        OfferResult e;
        Enum.TryParse(result.Value, out e);
        await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, e, refresh: true);
    }

    public void SetSelectedOption(string value)
    {
        var selectedOption = _offerResults.FirstOrDefault(item => item.Value == value);
        if (selectedOption != default)
        {
            _selectedResultValue = selectedOption.Value;
        }
    }
    #endregion

    #region Dialogs Functions
    private async Task _add(MouseEventArgs e)
    {
        var leadDto = Mapper.Map<LeadDto>(_selectedLead);
        var lead = Mapping.Mapper.Map<Lead>(leadDto);

        _selectedOffer = new OfferVM()
        {
            Lead = lead,
            LeadId = lead.Id,
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
            Width = "min(80%, 1000px);",
            Height = "min(80%, 1000px);"
        };

        _selectedOffer.LeadId = _selectedLead?.Id;

        IDialogReference dialog = await DialogService.ShowDialogAsync<OfferCreationDialog>(_selectedOffer, parameters);
        DialogResult result = await dialog.Result;

        if (result.Data is not null)
        {
            _selectedProject = _projects.FirstOrDefault(o => o.Name.Equals("Select Project..."));
            _selectedOfferState = _offerStates.FirstOrDefault(o => o.Name.Equals("Select State..."));
            _selectedOfferType = _offerTypes.FirstOrDefault(o => o.Name.Equals("Select Type..."));

            await _getLeads();
            OfferVM offerVMData = result.Data as OfferVM;
            _selectedLead = _leads?.FirstOrDefault(l => l.Id == offerVMData.LeadId);
            leadFilterCombo.Value = _selectedLead.Name;
            StateHasChanged();

            //_selectedOfferResult = OfferResult.WAITING.ToTuple();
            //OfferResult offerResult;
            //Enum.TryParse(_selectedOfferResult.Value, out offerResult);
            //resultFilterCombo.Value = _selectedOfferResult.Text;
            //StateHasChanged();

            // Update Result Filter To Waiting
            var waitingResult = offerVMData.Result.ToTuple();
            SetSelectedOption(waitingResult.Value);
            StateHasChanged();
            await _onResultSelectionChanged(waitingResult);

            OfferResult offerResult;
            Enum.TryParse(_selectedOfferResult.Value, out offerResult);

            await _getOffers(_selectedProject.Id,
                _selectedOfferState.Id, 
                _selectedOfferType.Id, 
                _selectedLead?.Id ?? 0, 
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
            Width = "min(80%, 1000px);",
            Height = "min(80%, 1000px);"
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
            await _onResultSelectionChanged(waitingResult);
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
            await _getOffers(_selectedProject.Id, _selectedOfferState.Id, _selectedOfferType.Id, _selectedLead?.Id ?? 0, or, true);
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
