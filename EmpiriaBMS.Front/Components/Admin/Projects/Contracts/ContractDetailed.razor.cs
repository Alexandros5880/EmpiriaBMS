using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Fast.Components.FluentUI;
using NuGet.Protocol;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Contracts;

public partial class ContractDetailed
{
    [Parameter]
    public ContractVM Content { get; set; } = default!;

    [Parameter]
    public FluentDialog Dialog { get; set; } = null;

    [Parameter]
    public bool DisplayActions { get; set; } = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair()
    {
        await _getRecords();

        if (Content.InvoiceId != 0)
        {
            var invoiceDto = _mapper.Map<InvoiceDto>(Content.Invoice);
            Invoice = Invoices.FirstOrDefault(i => i.Id == Content.InvoiceId);
        }
        else if (Content.Invoice != null)
        {
            Invoice = Content.Invoice;
        }

        StateHasChanged();
    }

    public async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;
    }

    #region Validation
    private bool validInvoice = true;
    private bool validContractualFee = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validInvoice = Content.Invoice != null;
            validContractualFee = Content.ContractualFee > 0;

            return validInvoice && validContractualFee;
        }
        else
        {
            validInvoice = true;

            switch (fieldname)
            {
                case "Invoice":
                    validInvoice = Content.Invoice != null;
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
    [Parameter]
    public List<InvoiceVM> Invoices { get; set; }

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
        if (Invoices == null || Invoices.Count == 0)
        {
            var dtos = await _dataProvider.Invoices.GetAll();
            Invoices = _mapper.Map<List<InvoiceVM>>(dtos);
        }
    }
    #endregion
}
