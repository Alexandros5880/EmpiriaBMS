using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Front.Components;
public partial class InvoiceDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;
    private bool isNew = false;

    [Parameter]
    public ProjectVM Project { get; set; }

    [Parameter]
    public InvoiceVM Invoice { get; set; }

    public void Prepair()
    {
        isNew = Project.ProjectsInvoices == null || Project.ProjectsInvoices.Count == 0;
        Invoice = new InvoiceVM();
        Invoice.ProjectsInvoices = new List<ProjectInvoice>();
        StateHasChanged();
    }

    public async Task HandleValidSubmit()
    {
        InvoiceDto myInvoice = Mapper.Map<InvoiceDto>(Invoice);
        
        // Save Invoice
        InvoiceDto saveInvoice;
        var exists = await DataProvider.Invoices.Any(i => i.Id == Invoice.Id);
        if (exists)
            saveInvoice = await DataProvider.Invoices.Update(myInvoice);
        else
            saveInvoice = await DataProvider.Invoices.Add(myInvoice);

        // Connect Invoice To Project
        await DataProvider.Projects.AddInvoice(Project.Id, saveInvoice.Id);
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