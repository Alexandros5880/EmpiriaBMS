using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Components.Projects;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace EmpiriaBMS.Front.Components;
public partial class InvoiceDetails : IDisposable
{
    private bool disposedValue;

    [Parameter]
    public InvoiceVM Invoice { get; set; }

    [Parameter]
    public Action<string> PropertyChanged { get; set; }

    protected override void OnParametersSet()
    {
        if (Invoice != null)
        {
            Invoice.PropertyChanged -= _onInvoiceChanged;
            Invoice.PropertyChanged += _onInvoiceChanged;
        }
    }

    private void _onInvoiceChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var id = (string)sender.GetType().GetProperty(nameof(InvoiceVM.Id)).GetValue(sender);
        if (id == null)
            return;

        PropertyChanged(id);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Invoice.PropertyChanged -= _onInvoiceChanged;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}