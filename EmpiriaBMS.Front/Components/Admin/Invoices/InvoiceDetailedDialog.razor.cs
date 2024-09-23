using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Horizontal;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
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

    public bool DisplayProject
    {
        get
        {
            if (Dialog == null || Dialog.Instance == null || Dialog.Instance.Parameters == null)
                return false;

            var parameters = Dialog.Instance.Parameters as MyDialogParameters;

            if (parameters == null)
                return false;

            var displayProject = parameters.DisplayProject;
            return displayProject;
        }
    }

    public bool IsWorkingMode
    {
        get
        {
            if (Dialog == null || Dialog.Instance == null || Dialog.Instance.Parameters == null)
                return false;

            var parameters = Dialog.Instance.Parameters as MyDialogParameters;

            if (parameters == null)
                return false;

            var isWorkingMode = parameters.IsWorkingMode;
            return isWorkingMode;
        }
    }

    public InvoiceCategory InvoiceCategory
    {
        get
        {
            if (Dialog == null || Dialog.Instance == null || Dialog.Instance.Parameters == null)
                return InvoiceCategory.EXPENSES;

            var parameters = Dialog.Instance.Parameters as MyDialogParameters;

            if (parameters == null)
                return InvoiceCategory.EXPENSES;

            var invoiceCategory = parameters.InvoiceCategory;
            return invoiceCategory;
        }
    }

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