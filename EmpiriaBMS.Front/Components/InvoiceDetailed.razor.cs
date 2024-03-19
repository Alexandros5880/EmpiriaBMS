using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace EmpiriaBMS.Front.Components;
public partial class InvoiceDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;

    [Parameter]
    public InvoiceVM Invoice { get; set; }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                
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