using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.Admin.Contracts;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Admin.Invoices;

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

    [Parameter]
    public EventCallback<InvoiceVM> OnSave { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    private InvoiceCategory? _invoiceCategory;
    [Parameter]
    public InvoiceCategory? InvoiceCategory
    {
        get => _invoiceCategory;
        set
        {
            if (value != null && value != _invoiceCategory)
            {
                _invoiceCategory = value;
                SelectedCategory = _categories.FirstOrDefault(r => r.Value == _invoiceCategory.ToString());
                _categoryCombo.Value = SelectedCategory.Text;
            }
        }
    }

    #region Fluent Combo Ref
    private FluentCombobox<ProjectVM> _projectCombo;
    private FluentCombobox<InvoiceTypeVM> _typeCombo;
    private FluentCombobox<(string Value, string Text)> _categoryCombo;

    private ContractDetailed _contractDetailedRef;

    private FluentCombobox<(string Value, string Text)> _vatCombo;
    #endregion

    #region Relaited Records Lists
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<InvoiceTypeVM> _types = new ObservableCollection<InvoiceTypeVM>();
    private List<(string Value, string Text)> _vats = Enum.GetValues(typeof(Vat)).Cast<Vat>()
                                                          .Select(e => e.ToTuple())
                                                          .ToList();

    private List<(string Value, string Text)> _categories = Enum.GetValues(typeof(InvoiceCategory))
                                                                .Cast<InvoiceCategory>()
                                                                .Select(e => e.ToTuple())
                                                                .ToList();
    #endregion

    #region Selected Relaited Records
    private ProjectVM _selectedProject = new ProjectVM();
    public ProjectVM SelectedProject
    {
        get => _selectedProject;
        set
        {
            if (_selectedProject == value || value == null) return;
            _selectedProject = value;
            Content.ProjectId = _selectedProject.Id;
        }
    }

    private InvoiceTypeVM _selectedType = new InvoiceTypeVM();
    public InvoiceTypeVM SelectedType
    {
        get => _selectedType;
        set
        {
            if (_selectedType == value || value == null) return;
            _selectedType = value;
            Content.TypeId = _selectedType.Id;
        }
    }

    private (string Value, string Text) _selectedVat;
    public (string Value, string Text) SelectedVat
    {
        get => _selectedVat;
        set
        {
            if (value == (null, null))
                return;

            _selectedVat = value;
            Vat vat = (Vat)Enum.Parse(typeof(Vat), value.Value);
            Content.Vat = vat;
        }
    }

    private (string Value, string Text) _selectedCategory;
    public (string Value, string Text) SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (value == (null, null))
                return;

            _selectedCategory = value;
            InvoiceCategory category = (InvoiceCategory)Enum.Parse(typeof(InvoiceCategory), value.Value);
            Content.Category = category;
        }
    }
    #endregion


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
            SelectedProject = _projects.FirstOrDefault(t => t.Id == Content.ProjectId);
            _projectCombo.Value = SelectedProject.Name;
        }

        if (Content.TypeId != 0)
        {
            SelectedType = _types.FirstOrDefault(t => t.Id == Content.TypeId);
            _typeCombo.Value = SelectedType.Name;
        }

        SelectedVat = _vats.FirstOrDefault(r => r.Value == Content.Vat.ToString());
        _vatCombo.Value = SelectedVat.Text;

        SelectedCategory = _categories.FirstOrDefault(r => r.Value == Content.Category.ToString());
        _categoryCombo.Value = SelectedCategory.Text;

        if (invoice == null && !halfRefresh)
            await _contractDetailedRef?.Prepair();
        else
            await _contractDetailedRef.Prepair(Contract, !halfRefresh);

        StateHasChanged();
    }

    public async Task Save()
    {
        var valid = Validate();
        if (!valid)
            return;

        var i = await _upsertInvoice(_invoice.Clone() as InvoiceVM);
        _contract.Invoice = i;
        _contract.InvoiceId = i.Id;
        var c = await _upsertContract(_contract.Clone() as ContractVM);

        i.Contract = c;
        i.ContractId = c.Id;

        Contract = new ContractVM()
        {
            Date = DateTime.Now,
        };
        Content = new InvoiceVM()
        {
            EstimatedDate = DateTime.Now,
            PaymentDate = DateTime.Now,
            Contract = Contract,
            ContractId = 0
        };
        Contract.Invoice = Content;
        Contract.InvoiceId = 0;

        await OnSave.InvokeAsync(i);
    }

    #region Update Records
    private async Task<InvoiceVM?> _upsertInvoice(InvoiceVM i)
    {
        if (i.ProjectId != 0)
        {
            var invoice = i.Clone() as InvoiceVM;
            invoice.ProjectId = SelectedProject.Id;
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
            validProject = !DisplayProject || SelectedProject.Id != 0;
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
                    validProject = !DisplayProject || SelectedProject.Id != 0;
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
            else
            {
                Contract = new ContractVM()
                {
                    Date = DateTime.Now,
                    Invoice = Content,
                    InvoiceId = Content.Id,
                };
                Content.Contract = Contract;
                Content.Id = Content.Id;
            }

        }

        if (_contractDetailedRef != null && Contract != null)
        {
            Contract.Invoice = Content;
            Contract.InvoiceId = Content.Id;
            await _contractDetailedRef.Prepair(Contract, false);
        }

    }
    #endregion
}