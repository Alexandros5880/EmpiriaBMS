using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using EmpiriaMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Kiota.Abstractions;
using SQLitePCL;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace EmpiriaBMS.Front.Components;

public partial class Invoices : ComponentBase, IDisposable
{
    private bool disposedValue;

    private ObservableCollection<InvoiceVM> _allInvoices = new ObservableCollection<InvoiceVM>();
    private ObservableCollection<InvoiceVM> _projectsInvoices = new ObservableCollection<InvoiceVM>();
    private List<InvoiceVM> _deleted = new List<InvoiceVM>();

    [Parameter]
    public ProjectVM Project { get; set; }

    public async Task Prepair()
    {
        await _getProjectsInvoices();
        await _getAllInvoices();

        StateHasChanged();
    }

    private async Task _getAllInvoices()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Invoices.GetAll();
            var invoices = _mapper.Map<List<InvoiceVM>>(dtos);
            _allInvoices.Clear();
            invoices.ForEach(_allInvoices.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private async Task _getProjectsInvoices()
    {
        try
        {
            // Get My Invoices
            var dtos = await _dataProvider.Projects.GetInvoices(Project.Id);
            var invoices = _mapper.Map<List<InvoiceVM>>(dtos);
            _projectsInvoices.Clear();
            invoices.ForEach(_projectsInvoices.Add);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            // TODO: Log Error
        }
    }

    private void _onInvoiceSelected(ChangeEventArgs e)
    {
        var selectedInvoiceId = Convert.ToInt32((string)e.Value);
        var selectedInvoice = _allInvoices.FirstOrDefault(i => i.Id == selectedInvoiceId);
        if (selectedInvoice != null)
        {
            var newInvoice = new InvoiceVM(selectedInvoice);
            newInvoice.ProjectId = Project.Id;
            newInvoice.Id = 0;
            _projectsInvoices.Add(selectedInvoice);
        }
    }

    private async Task _deleteInvoice(InvoiceVM invoice)
    {
        if (invoice.Id != 0)
            _deleted.Add(invoice);
        _projectsInvoices.Remove(invoice);
    }

    private async Task _addInvoice()
    {
        _projectsInvoices.Add(new InvoiceVM()
        {
            ProjectId = Project.Id,
            Type = InvoiceType.Income,
            Date = DateTime.Now,
            Vat = 24,
        });
    }

    private async Task _save()
    {
        // For Delete
        if (_deleted.Count > 0)
        {
            foreach (var invoice in _deleted)
            {
                await _dataProvider.Invoices.Delete(invoice.Id);
            }
        }

        // For Update
        foreach (var invoice in _projectsInvoices.Where(i => i.Id != 0))
        {
            var dto = _mapper.Map<InvoiceDto>(invoice);
            await _dataProvider.Invoices.Update(dto);
        }

        // For Add
        if (_projectsInvoices.Any(i => i.Id == 0))
        {
            foreach (var invoice in _projectsInvoices.Where(i => i.Id == 0))
            {
                var dto = _mapper.Map<InvoiceDto>(invoice);
                await _dataProvider.Invoices.Add(dto);
            }
        }
        
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _allInvoices.Clear();
                _allInvoices = null;

                _projectsInvoices.Clear();
                _projectsInvoices = null;

                _deleted.Clear();
                _deleted = null;
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
