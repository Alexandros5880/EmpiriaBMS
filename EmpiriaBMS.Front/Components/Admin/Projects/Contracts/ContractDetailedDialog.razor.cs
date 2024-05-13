using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Contracts;

public partial class ContractDetailedDialog : IDialogContentComponent<ContractVM>
{
    [Parameter]
    public ContractVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Content.Invoice != null)
            {
                var invoiceDto = _mapper.Map<InvoiceDto>(Content.Invoice);
                Invoice = _mapper.Map<InvoiceVM>(invoiceDto);
            }

            StateHasChanged();
        }
    }

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Validation
    private bool validInvoice = true;
    private bool validContractualFee = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validInvoice = Content.InvoiceId != 0 && Content.InvoiceId != null;
            validContractualFee = Content.ContractualFee > 0;

            return validInvoice && validContractualFee;
        }
        else
        {
            validInvoice = true;

            switch (fieldname)
            {
                case "Invoice":
                    validInvoice = Content.InvoiceId != 0 && Content.InvoiceId != null;
                    return validInvoice;
                case "ContractualFee":
                    validContractualFee = Content.ContractualFee > 0;
                    return validContractualFee;

                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<InvoiceVM> _invoices = new ObservableCollection<InvoiceVM>();

    private InvoiceVM _invoice = new InvoiceVM();
    public InvoiceVM Invoice
    {
        get => _invoice;
        set
        {
            if (_invoice == value || value == null) return;
            _invoice = value;
            Content.InvoiceId = _invoice.Id;
        }
    }


    private async Task _getRecords()
    {
        await _getInvoices();
    }

    private async Task _getInvoices()
    {
        var dtos = await _dataProvider.Invoices.GetAll();
        var vms = _mapper.Map<List<InvoiceVM>>(dtos);
        _invoices.Clear();
        vms.ForEach(_invoices.Add);
    }
    #endregion
}