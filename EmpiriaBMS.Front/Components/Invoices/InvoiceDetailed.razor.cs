using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
namespace EmpiriaBMS.Front.Components.Invoices;

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
            }
        }
    }

    [Parameter]
    public string Title { get; set; } = null;

    [Parameter]
    public bool DisplayAcions { get; set; } = true;

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
                if (_categoryCombo != null)
                    _categoryCombo.Value = SelectedCategory.Text;
            }
        }
    }

    #region Fluent Combo Ref
    private FluentCombobox<ProjectVM> _projectCombo;
    private FluentCombobox<ExpensesTypeVM> _expenseTypeCombo;
    private FluentCombobox<InvoiceTypeVM> _typeCombo;
    private FluentCombobox<(string Value, string Text)> _categoryCombo;
    #endregion

    #region Relaited Records Lists
    ObservableCollection<ProjectVM> _projects = new ObservableCollection<ProjectVM>();
    ObservableCollection<ExpensesTypeVM> _expensesTypes = new ObservableCollection<ExpensesTypeVM>();
    ObservableCollection<InvoiceTypeVM> _types = new ObservableCollection<InvoiceTypeVM>();

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

    private ExpensesTypeVM _selectedExpType = new ExpensesTypeVM();
    public ExpensesTypeVM SelectedExpType
    {
        get => _selectedExpType;
        set
        {
            if (_selectedExpType == value || value == null) return;
            _selectedExpType = value;
            Content.ExpensesTypeId = _selectedExpType.Id;
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

        if (Content.Project != null)
        {
            SelectedProject = _projects.FirstOrDefault(t => t.Id == Content.ProjectId);
            if (_projectCombo != null)
                _projectCombo.Value = SelectedProject.Name;
        }

        if (Content.TypeId != 0)
        {
            SelectedType = _types.FirstOrDefault(t => t.Id == Content.TypeId);
            if (_typeCombo != null)
                _typeCombo.Value = SelectedType.Name;
        }

        SelectedCategory = _categories.FirstOrDefault(r => r.Value == Content.Category.ToString());
        if (_categoryCombo != null)
            _categoryCombo.Value = SelectedCategory.Text;

        StateHasChanged();
    }

    public async Task Save()
    {
        var valid = Validate();
        if (!valid)
            return;

        var i = await _upsertInvoice(_invoice.Clone() as InvoiceVM);

        if (i == null)
            return;

        Content = new InvoiceVM()
        {
            EstimatedPayment = DateTime.Now,
            ActualPayment = DateTime.Now
        };

        await OnSave.InvokeAsync(i);
    }

    #region Update Records
    private async Task<InvoiceVM?> _upsertInvoice(InvoiceVM i)
    {
        if (i.ProjectId != 0)
        {
            var invoice = i.Clone() as InvoiceVM;
            invoice.Project = null;
            invoice.Type = null;
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
    #endregion

    #region Validation
    private bool validProject = true;
    private bool validMark = true;
    private bool validType = true;

    public bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validProject = SelectedProject.Id != 0;
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
                    validProject = SelectedProject.Id != 0;
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
        await _getExpTypes();
        await _getTypes();
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

    private async Task _getExpTypes()
    {
        var dtos = await _dataProvider.ExpensesTypes.GetAll();
        var vms = _mapper.Map<List<ExpensesTypeVM>>(dtos);
        _expensesTypes.Clear();
        vms.ForEach(_expensesTypes.Add);
    }
    #endregion
}