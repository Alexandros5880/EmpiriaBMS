using EmpiriaBMS.Front.Components.Invoices;
using EmpiriaBMS.Front.Components.KPIS.Base;
using ComReports = EmpiriaBMS.Front.Components.Reports;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.CodeAnalysis;
using OffersComp = EmpiriaBMS.Front.Components.Home.Offers.Offers;
using DevComp = EmpiriaBMS.Front.Components.Home.Deliverables;
using DiscComp = EmpiriaBMS.Front.Components.Home.Disciplines;
using SWComp = EmpiriaBMS.Front.Components.Home.SupportiveWorks;
using projComp = EmpiriaBMS.Front.Components.Home.Projects;
using Microsoft.CodeAnalysis.CSharp;
using EmpiriaBMS.Front.Components.Home;
using ClientsComp = EmpiriaBMS.Front.Components.Home.Clients;

namespace EmpiriaBMS.Front.Components;
public partial class Dashboard
{
    #region Authorization Properties
    bool isEmployee => _sharedAuthData.IsLogedUserEmployee;
    bool assignDesigner => _sharedAuthData.PermissionOrds.Contains(3);
    bool assignEngineer => _sharedAuthData.PermissionOrds.Contains(4);
    bool assignPm => _sharedAuthData.PermissionOrds.Contains(5);
    bool editMyHours => _sharedAuthData.PermissionOrds.Contains(2);
    bool seeMyHours => _sharedAuthData.PermissionOrds.Contains(8);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    bool editProject => _sharedAuthData.Permissions.Any(p => p.Ord == 12);
    bool editDiscipline => _sharedAuthData.Permissions.Any(p => p.Ord == 14);
    bool editDeliverable => _sharedAuthData.Permissions.Any(p => p.Ord == 15);
    bool editSupportiveWork => _sharedAuthData.Permissions.Any(p => p.Ord == 16);
    bool seeKpis => _sharedAuthData.Permissions.Any(p => p.Ord == 17);
    bool seeAdmin => _sharedAuthData.Permissions.Any(p => p.Ord == 7);
    bool seeOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 24);
    bool seeTeamsRequestedUsers => _sharedAuthData.Permissions.Any(p => p.Ord == 28);
    bool seeInvoices => _sharedAuthData.Permissions.Any(p => p.Ord == 29);
    bool seeExpenses => _sharedAuthData.Permissions.Any(p => p.Ord == 30);
    bool workOnProject => _sharedAuthData.Permissions.Any(p => p.Ord == 31);
    bool workOnOffers => _sharedAuthData.Permissions.Any(p => p.Ord == 32);
    bool workOnLeds => _sharedAuthData.Permissions.Any(p => p.Ord == 33);
    bool seeNextYearIncome => _sharedAuthData.Permissions.Any(p => p.Ord == 34);
    bool seeBackupDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 35);
    bool seeRestoreDatabase => _sharedAuthData.Permissions.Any(p => p.Ord == 36);
    bool canChangeEverybodyHours => _sharedAuthData.Permissions.Any(p => p.Ord == 37);
    bool seeClientsOnDashboard => _sharedAuthData.Permissions.Any(p => p.Ord == 38);
    bool canApproveTimeRequests => _sharedAuthData.Permissions.Any(p => p.Ord == 39);
    bool seeTimeMGMT => _sharedAuthData.Permissions.Any(p => p.Ord == 40);
    #endregion

    // General Fields
    bool _runInTeams = true;
    bool _startLoading = true;
    bool _isWorkingMode = false;

    #region Compoment Refrense
    private Invoices.Invoices _invoiceIncomesListRef;
    private Invoices.Invoices _invoiceExpensesListRef;
    private KPIDashboard _kpiDashRef;
    private ComReports.TimeMGMT _timeMGMTRef;
    #endregion

    #region Selected Models
    private ClientVM _selectedClient = new ClientVM();
    private OfferVM _selectedOffer = new OfferVM();
    private InvoiceVM _selectedIncomeInvoice = new InvoiceVM();
    private InvoiceVM _selectedExpenseInvoice = new InvoiceVM();
    #endregion

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (_sharedAuthData.LogedUser == null)
        {
            MyNavigationManager.NavigateTo("/loginpage");
            return;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _runInTeams = await MicrosoftTeams.IsInTeams();
            _startLoading = false;
            StateHasChanged();
        }
    }

    private void _onWorkingModeChanged(bool workMode)
    {
        _isWorkingMode = workMode;
        StateHasChanged();
    }

    #region Tab Actions
    private string _activeid = "tab-home";
    #endregion

    #region Invoice
    private InvoiceDetailed _invoiceIncomeDetailedRef;
    private InvoiceDetailed _invoiceExpenseDetailedRef;
    private Payments _invoiceIncomePaymentsRef;
    private Payments _invoiceExpensePaymentsRef;

    private async Task _onSelectedIncomeInvoice(InvoiceVM invoice)
    {
        if (invoice == null)
            return;

        _selectedIncomeInvoice = invoice;
        if (_invoiceIncomeDetailedRef != null)
        {
            await _invoiceIncomeDetailedRef.Prepair(_selectedIncomeInvoice, true);
            await _invoiceIncomePaymentsRef.Prepair(_selectedIncomeInvoice.Id);
        }
    }

    private async Task _onSaveIncomeInvoice(InvoiceVM invoice)
    {
        if (_invoiceIncomesListRef != null)
        {
            await _invoiceIncomesListRef.Refresh();
            await _invoiceIncomeDetailedRef.Prepair();
            await _invoiceIncomePaymentsRef.Prepair(_selectedIncomeInvoice.Id);
        }

    }

    private async Task _onSelectedExpenseInvoice(InvoiceVM invoice)
    {
        if (invoice == null)
            return;

        _selectedExpenseInvoice = invoice;
        if (_invoiceExpenseDetailedRef != null)
        {
            await _invoiceExpenseDetailedRef.Prepair(_selectedExpenseInvoice, true);
            await _invoiceExpensePaymentsRef.Prepair(_selectedExpenseInvoice.Id);
        }
    }

    private async Task _onSaveExpenseInvoice(InvoiceVM invoice)
    {
        if (_invoiceExpensesListRef != null)
        {
            await _invoiceExpensesListRef.Refresh();
            await _invoiceExpenseDetailedRef.Prepair();
            await _invoiceExpensePaymentsRef.Prepair(_selectedExpenseInvoice.Id);
        }

    }

    private void _onPaymentChanged()
    {
        StateHasChanged();
    }
    #endregion
}
