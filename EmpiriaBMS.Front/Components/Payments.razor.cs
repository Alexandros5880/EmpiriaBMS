using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;

public partial class Payments : ComponentBase, IDisposable
{
    private bool disposedValue;

    private ObservableCollection<InvoiceVM> _projectsInvoices = new ObservableCollection<InvoiceVM>();
    private ObservableCollection<PaymentTypeVM> _types = new ObservableCollection<PaymentTypeVM>();
    private ObservableCollection<PaymentVM> _allPayments = new ObservableCollection<PaymentVM>();
    private ObservableCollection<PaymentVM> _invoicesPayments = new ObservableCollection<PaymentVM>();
    private List<PaymentVM> _deleted = new List<PaymentVM>();

    [Parameter]
    public ProjectVM Project { get; set; }
    private InvoiceVM _selectedInvoice;

    public async Task Prepair()
    {
        await _getProjectsInvoices();
        await _getPaymentsTypes();
        //await _getAllPayments();

        StateHasChanged();
    }

    private async Task _getProjectsInvoices()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Projects.GetInvoices(Project.Id);
            var invoices = _mapper.Map<List<InvoiceVM>>(dtos);
            _projectsInvoices.Clear();
            invoices.ForEach(i => {
                i.Type = null;
                i.Project = null;
                _projectsInvoices.Add(i);
            });

            _selectedInvoice = _projectsInvoices.FirstOrDefault();
            await _getInvoicePayments(_selectedInvoice.Id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getPaymentsTypes()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.PaymentTypes.GetAll();
            var paymentsTypes = _mapper.Map<List<PaymentTypeVM>>(dtos);
            _types.Clear();
            paymentsTypes.ForEach(_types.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getInvoicePayments(int invoiceId)
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Invoices.GetInvoicesPayments(invoiceId);
            var payments = _mapper.Map<List<PaymentVM>>(dtos);
            _invoicesPayments.Clear();
            payments.ForEach(i =>
            {
                i.Type = null;
                i.Invoice = null;
                _invoicesPayments.Add(i);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _onInvoiceSelected(ChangeEventArgs e)
    {
        var selectedInvoiceId = Convert.ToInt32((string)e.Value);
        _selectedInvoice = _projectsInvoices.FirstOrDefault(i => i.Id == selectedInvoiceId);
        await _getInvoicePayments(selectedInvoiceId);
    }

    private void _deletePayment(PaymentVM payment)
    {
        if (payment.Id != 0)
            _deleted.Add(payment);
        _invoicesPayments.Remove(payment);
    }

    private void _addPayment()
    {
        _invoicesPayments.Add(new PaymentVM()
        {
            InvoiceId = _selectedInvoice.Id,
            TypeId = _types.FirstOrDefault().Id,
        });
    }

    private async Task _save()
    {
        try
        {
            // For Delete
            if (_deleted.Count > 0)
            {
                foreach (var payment in _deleted)
                {
                    await _dataProvider.Payments.Delete(payment.Id);
                }
            }

            // For Update
            var updatedPayments = _invoicesPayments.Where(i => i.Id != 0).ToList();
            if (updatedPayments.Count() > 0)
            {
                foreach (var payment in updatedPayments)
                {
                    payment.Type = null;
                    var dto = _mapper.Map<PaymentDto>(payment);
                    await _dataProvider.Payments.Update(dto);
                }
            }

            // For Add
            if (_invoicesPayments.Any(i => i.Id == 0))
            {
                var newPayments = _invoicesPayments.Where(i => i.Id == 0).ToList();
                foreach (var payment in newPayments)
                {
                    payment.Type = null;
                    var dto = _mapper.Map<PaymentDto>(payment);
                    await _dataProvider.Payments.Add(dto);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }

        await Prepair();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _projectsInvoices.Clear();
                _projectsInvoices = null;
                _types.Clear();
                _types = null;
                _allPayments.Clear();
                _allPayments = null;
                _invoicesPayments.Clear();
                _invoicesPayments = null;
                _deleted.Clear();
                _deleted = null;
            }
            disposedValue = true;
        }
    }

    #region Display Helper Functions
    private string _displayDayesUntilPayment(PaymentVM payment)
    {
        var paymentDay = @payment.PaymentDate ?? DateTime.Now;
        var diffTime = paymentDay - DateTime.Now;
        return diffTime.DisplayDHMS();
    }
    #endregion


    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
