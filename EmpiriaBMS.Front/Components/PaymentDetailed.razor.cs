using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class PaymentDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public int ProjectId { get; set; }

    public InvoiceVM _invoice { get; set; }

    public void PrepairForNew()
    {
        isNew = true;
        _invoice = new InvoiceVM();
        _invoice.ProjectId = ProjectId;
        StateHasChanged();
    }

    public void PrepairForEdit(InvoiceVM invoice)
    {
        isNew = false;
        _invoice = invoice;
        StateHasChanged();
    }

    public async Task HandleValidSubmit()
    {
        //OtherDto myOther = Mapper.Map<OtherDto>(_other);
        //// Save Other
        //OtherDto saveOther;
        //var exists = await DataProvider.Others.Any(p => p.Id == _other.Id);
        //if (exists)
        //    saveOther = await DataProvider.Others.Update(myOther);
        //else
        //    saveOther = await DataProvider.Others.Add(myOther);
    }

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