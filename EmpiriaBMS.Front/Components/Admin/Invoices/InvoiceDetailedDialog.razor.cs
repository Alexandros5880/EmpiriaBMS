using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Horizontal;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Invoices;

public partial class InvoiceDetailedDialog : IDialogContentComponent<InvoiceVM>
{
    [Parameter]
    public InvoiceVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private InvoiceDetailed _compomentRef;

    private async Task SaveAsync()
    {
        var valid = _compomentRef.Validate();
        if (valid)
        {
            await _compomentRef.Save();
            await Dialog.CloseAsync(Content);
        }
    }

    private async Task CancelAsync() =>
        await Dialog.CancelAsync();
}