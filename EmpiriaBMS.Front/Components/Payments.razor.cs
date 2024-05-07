using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;

public partial class Payments : ComponentBase, IDisposable
{
    private bool disposedValue;

    private ObservableCollection<InvoiceVM> _invoices = new ObservableCollection<InvoiceVM>();
    private ObservableCollection<PaymentTypeVM> _types = new ObservableCollection<PaymentTypeVM>();
    private ObservableCollection<PaymentVM> _payments = new ObservableCollection<PaymentVM>();
    private List<PaymentVM> _deleted = new List<PaymentVM>();

    [Parameter]
    public ProjectVM Project { get; set; }

    public async Task Prepair()
    {
        await _getProjectsInvoices();
        await _getPaymentsTypes();

        StateHasChanged();
    }

    private async Task _getProjectsInvoices()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Projects.GetInvoices(Project.Id);
            var invoices = _mapper.Map<List<InvoiceVM>>(dtos);
            _invoices.Clear();
            invoices.ForEach(i => {
                i.Type = null;
                i.Project = null;
                _invoices.Add(i);
            });

            await _getPayments();
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

    private async Task _getPayments()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Invoices.GetProjectsPayments(Project.Id);
            var payments = _mapper.Map<List<PaymentVM>>(dtos);
            _payments.Clear();
            payments.ForEach(i =>
            {
                i.Type = null;
                i.Invoice = null;
                _payments.Add(i);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private void _deletePayment(PaymentVM payment)
    {
        if (payment.Id != 0)
            _deleted.Add(payment);
        _payments.Remove(payment);
    }

    private void _addPayment()
    {
        _payments.Add(new PaymentVM()
        {
            InvoiceId = _invoices.FirstOrDefault().Id,
            TypeId = _types.FirstOrDefault().Id,
            EstimatedDate = DateTime.Now.AddMonths(1),
            PaymentDate = DateTime.Now.AddMonths(1),
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
                _deleted.Clear();
            }

            // For Update
            var updatedPayments = _payments.Where(i => i.Id != 0).ToList();
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
            if (_payments.Any(i => i.Id == 0))
            {
                var newPayments = _payments.Where(i => i.Id == 0).ToList();
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
                _invoices.Clear();
                _invoices = null;
                _types.Clear();
                _types = null;
                _payments.Clear();
                _payments = null;
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
