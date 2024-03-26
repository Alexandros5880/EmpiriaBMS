using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class PaymentDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public ProjectVM Project { get; set; }

    [Parameter]
    public PaymentVM Payment { get; set; }

    public void Prepair()
    {
        isNew = Project.Payment == null;
        if (isNew)
            Payment = new PaymentVM();
        Payment.ProjectId = Project.Id;
        StateHasChanged();
    }

    public async Task HandleValidSubmit()
    {
        PaymentDto myPayment = Mapper.Map<PaymentDto>(Payment);
        // Save Payment
        PaymentDto savePayment;
        var exists = await DataProvider.Payments.Any(i => i.Id == Payment.Id);
        if (exists)
            savePayment = await DataProvider.Payments.Update(myPayment);
        else
            savePayment = await DataProvider.Payments.Add(myPayment);
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