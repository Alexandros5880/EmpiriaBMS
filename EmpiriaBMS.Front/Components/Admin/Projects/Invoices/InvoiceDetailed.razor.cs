using AutoMapper;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Invoices;

public partial class InvoiceDetailed
{
    private InvoiceVM _invoice;
    [Parameter]
    public InvoiceVM Content
    {
        get => _invoice;
        set
        {
            if (value != _invoice && value != null)
            {
                _invoice = value;
                Contract = value.Contract;
            }
        }
    }

    private ContractVM _contract;
    [Parameter]
    public ContractVM Contract
    {
        get => _contract;
        set
        {
            if (value != _contract && value != null)
            {
                _contract = value;
                Content.Contract = value;
                Content.ContractId = value?.Id;
            }
        }
    }

    [Parameter]
    public string Title { get; set; } = null;

    [Parameter]
    public bool DisplayAcions { get; set; } = true;

    [Parameter]
    public bool DisplayProject { get; set; } = false;

    private FluentCombobox<InvoiceTypeVM> _typeCompoment;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await Prepair();
        }
    }

    public async Task Prepair(InvoiceVM invoice = null, bool halfRefresh = false)
    {
        if (!halfRefresh)
            await _getRecords();

        if (invoice != null)
            Content = invoice;

        if (halfRefresh)
            await _getRelatedContract();

        if (Content.Project != null)
        {
            var projectDto = _mapper.Map<ProjectDto>(Content.Project);
            Project = _mapper.Map<ProjectVM>(projectDto);
        }

        if (Content.TypeId != 0)
        {
            Type = _types.FirstOrDefault(t => t.Id == Content.TypeId);
            if (_typeCompoment != null)
            {
                _typeCompoment.SelectedOption = Type;
                _typeCompoment.Value = Type.Name;
            }
        }

        StateHasChanged();
    }

    public async Task<InvoiceVM> Save()
    {
        var valid = Validate();
        if (!valid)
            return null;

        var i = await _upsertInvoice(_invoice.Clone() as InvoiceVM);
        _contract.Invoice = i;
        _contract.InvoiceId = i.Id;
        var c = await _upsertContract(_contract.Clone() as ContractVM);

        i.Contract = c;
        i.ContractId = c.Id;

        StateHasChanged();
        return i;
    }

    #region Update Records
    private async Task<InvoiceVM?> _upsertInvoice(InvoiceVM i)
    {
        if (i is not null && i.Project != null && i.ProjectId != 0)
        {
            var invoice = i.Clone() as InvoiceVM;
            invoice.ProjectId = _project.Id;
            invoice.Type = null;
            invoice.Contract = null;
            invoice.ContractId = null;
            invoice.Project = null;

            var dto = _mapper.Map<InvoiceDto>(invoice);

            // Save Invoice
            if (await _dataProvider.Invoices.Any(p => p.Id == invoice.Id))
            {
                InvoiceDto updatedInvoice = await _dataProvider.Invoices.Update(dto);
                if (updatedInvoice != null)
                    return _mapper.Map<InvoiceVM>(updatedInvoice);
                else
                    return null;
            }
            else
            {
                InvoiceDto updatedInvoice = await _dataProvider.Invoices.Add(dto);
                if (updatedInvoice != null)
                    return _mapper.Map<InvoiceVM>(updatedInvoice);
                else
                    return null;
            }

        }
        else
            return null;
    }

    private async Task<ContractVM> _upsertContract(ContractVM contract)
    {
        if (contract is not null && contract.Invoice != null && contract.InvoiceId != 0)
        {
            contract.Invoice = null;

            var dto = _mapper.Map<ContractDto>(contract);
            // Save Contract
            if (await _dataProvider.Contracts.Any(p => p.Id == contract.Id))
            {
                ContractDto updated = await _dataProvider.Contracts.Update(dto);
                if (updated != null)
                    return _mapper.Map<ContractVM>(updated);
                else
                    return null;
            }
            else
            {
                ContractDto updated = await _dataProvider.Contracts.Add(dto);
                if (updated != null)
                    return _mapper.Map<ContractVM>(updated);
                else
                    return null;
            }
        }
        else
            return null;
    }
    #endregion

    #region Validation
    private bool validProject = true;
    private bool validMark = true;
    private bool validType = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = !DisplayProject || Content.ProjectId != 0 && Content.ProjectId != null;
            validMark = !string.IsNullOrEmpty(Content.Mark);
            validType = Content.TypeId != 0;


            return validMark && validType && validProject;
        }
        else
        {
            validProject = true;
            validMark = true;
            validType = true;

            switch (fieldname)
            {
                case "Project":
                    validProject = !DisplayProject || Content.ProjectId != 0 && Content.ProjectId != null;
                    return validProject;
                case "Mark":
                    validMark = !string.IsNullOrEmpty(Content.Mark);
                    return validMark;
                case "Type":
                    validType = Content.TypeId != 0;
                    return validType;

                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<InvoiceTypeVM> _types = new ObservableCollection<InvoiceTypeVM>();

    private ProjectVM _project = new ProjectVM();
    public ProjectVM Project
    {
        get => _project;
        set
        {
            if (_project == value || value == null) return;
            _project = value;
            Content.ProjectId = _project.Id;
        }
    }

    private InvoiceTypeVM _type = new InvoiceTypeVM();
    public InvoiceTypeVM Type
    {
        get => _type;
        set
        {
            if (_type == value || value == null) return;
            _type = value;
            Content.TypeId = _type.Id;
        }
    }

    private async Task _getRecords()
    {
        await _getProjects();
        await _getTypes();
        await _getRelatedContract();
    }

    private async Task _getProjects()
    {
        var dtos = await _dataProvider.Projects.GetAll();
        var vms = _mapper.Map<List<ProjectVM>>(dtos);
        _projects.Clear();
        vms.ForEach(_projects.Add);
    }

    private async Task _getTypes()
    {
        var dtos = await _dataProvider.InvoiceTypes.GetAll();
        var vms = _mapper.Map<List<InvoiceTypeVM>>(dtos);
        _types.Clear();
        vms.ForEach(_types.Add);
    }

    private async Task _getRelatedContract()
    {
        if (Content.Id != 0)
        {
            var contractDto = await _dataProvider.Invoices.GetContract(Content.Id);
            if (contractDto != null)
                Contract = _mapper.Map<ContractVM>(contractDto);
        }
    }
    #endregion
}
