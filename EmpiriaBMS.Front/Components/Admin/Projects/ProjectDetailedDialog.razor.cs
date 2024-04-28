using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Kiota.Abstractions;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects;

public partial class ProjectDetailedDialog : IDialogContentComponent<ProjectVM>
{
    [Parameter]
    public ProjectVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    ObservableCollection<ProjectCategoryVM> _categories = new ObservableCollection<ProjectCategoryVM>();
    ObservableCollection<ProjectSubCategoryVM> _subCategories = new ObservableCollection<ProjectSubCategoryVM>();
    ObservableCollection<ProjectStageVM> _stages = new ObservableCollection<ProjectStageVM>();
    ObservableCollection<UserVM> _pms = new ObservableCollection<UserVM>();
    ObservableCollection<ClientVM> _clients = new ObservableCollection<ClientVM>();

    public ProjectCategoryVM _category = new ProjectCategoryVM();
    public ProjectCategoryVM Category
    {
        get => _category;
        set
        {
            if (_category == value || value == null) return;
            _category = value;
            Content.Category.CategoryId = _category.Id;
            _getSubCategories();
            SubCategory = null;
            StateHasChanged();
        }
    }
    
    private ProjectSubCategoryVM _subCategory = new ProjectSubCategoryVM();
    public ProjectSubCategoryVM SubCategory
    {
        get => _subCategory;
        set
        {
            if (_subCategory == value || value == null) return;
            _subCategory = value;
            Content.CategoryId = _subCategory?.Id ?? 0;
        }
    }

    private ProjectStageVM _stage = new ProjectStageVM();
    public ProjectStageVM Stage
    {
        get => _stage;
        set
        {
            if (_stage == value || value == null) return;
            _stage = value;
            Content.StageId = _stage.Id;
        }
    }

    private UserVM _pm = new UserVM();
    public UserVM Pm
    {
        get => _pm;
        set
        {
            if (_pm == value || value == null) return;
            _pm = value;
            Content.ProjectManagerId = _pm.Id;
        }
    }

    private ClientVM _client = new ClientVM();
    public ClientVM Client
    {
        get => _client;
        set
        {
            if (_client == value || value == null) return;
            _client = value;
            Content.ClientId = _client.Id;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            if (Content.Id != 0)
                await _map.SetAddress(Content.Address);

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

    #region Client && Autocomplete
    FluentAutocomplete<ClientVM> ClientsList = default!;
    private bool _diplayedClientForm = false;
    private void OnClientSearch(OptionsSearchEventArgs<ClientVM> e)
    {
        e.Items = _clients.Where(i => i.FullName.Contains(e.Text, StringComparison.OrdinalIgnoreCase))
                          .OrderBy(i => i.LastName);
    }

    private void _addClient()
    {
        _diplayedClientForm = true;
        StateHasChanged();
    }

    private void _closeClientForm(ClientVM client = null)
    {
        if (client != null) Client = client;
        else  Client = null;
        _diplayedClientForm = false;
        StateHasChanged();
    }
    #endregion

    #region Validation
    private bool validName = true;
    private bool validCode = true;
    private bool validCategory = true;
    private bool validSubCategory = true;
    private bool validStage = true;
    private bool validPm = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);
            validCode = !string.IsNullOrEmpty(Content.Code);
            validCategory = _category != null;
            validSubCategory = Content.CategoryId != 0;
            validStage = Content.StageId != 0;
            validPm = Content.ProjectManagerId != 0 && Content.ProjectManagerId != null;

            return validName && validCode && validCategory && validSubCategory && validStage && validPm;
        }
        else
        {
            validName = true;
            validCode = true;
            validCategory = true;
            validStage = true;
            validPm = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                case "Code":
                    validCode = !string.IsNullOrEmpty(Content.Code);
                    return validCode;
                case "Category":
                    validCategory = _category != null;
                    return validCategory;
                case "SubCategory":
                    validSubCategory = Content.CategoryId != 0;
                    return validSubCategory;
                case "Stage":
                    validStage = Content.StageId != 0;
                    return validStage;
                case "PM":
                    validPm = Content.ProjectManagerId != 0;
                    return validPm;
                default:
                    return true;
            }

        }
    }
    #endregion

    #region Get Related Records
    private async Task _getRecords()
    {
        await _getCategories();
        await _getStages();
        await _getProjectManagers();
        await _getClients();
    }

    private async Task _getCategories()
    {
        var dtos = await DataProvider.ProjectsCategories.GetAll();
        var vms = Mapper.Map<List<ProjectCategoryVM>>(dtos);
        _categories.Clear();
        vms.ForEach(_categories.Add);

        Category = _categories.FirstOrDefault(c => c.Id == Content.Category?.CategoryId) ?? null;
        SubCategory = null;
    }

    private async Task _getSubCategories(bool refresh = false)
    {
        if (_category == null) return;
        var dtos = await DataProvider.ProjectsSubCategories.GetAll(_category.Id);
        var vms = Mapper.Map<List<ProjectSubCategoryVM>>(dtos);
        _subCategories.Clear();
        vms.ForEach(_subCategories.Add);

        SubCategory = _subCategories.FirstOrDefault(c => c.Id == Content.CategoryId) ?? null;

        if (refresh)
            StateHasChanged();
    }

    private async Task _getStages()
    {
        var dtos = await DataProvider.ProjectStages.GetAll();
        var vms = Mapper.Map<List<ProjectStageVM>>(dtos);
        _stages.Clear();
        vms.ForEach(_stages.Add);

        Stage = _stages.FirstOrDefault(c => c.Id == Content.StageId) ?? null;
    }

    private async Task _getProjectManagers()
    {
        var dtos = await DataProvider.Users.GetProjectManagers();
        var vms = Mapper.Map<List<UserVM>>(dtos);
        _pms.Clear();
        vms.ForEach(_pms.Add);

        Pm = _pms.FirstOrDefault(c => c.Id == Content.ProjectManagerId) ?? null;
    }

    private async Task _getClients()
    {
        var dtos = await DataProvider.Clients.GetAll();
        var vms = Mapper.Map<List<ClientVM>>(dtos);
        _clients.Clear();
        vms.ForEach(_clients.Add);

        Client = _clients.FirstOrDefault(c => c.Id == Content.ClientId) ?? null;
    }
    #endregion

    #region Map Address
    private Map _map;

    private void _onSearchAddressChange()
    {
        var address = _map.GetAddress();
        if (address != null)
            Content.Address = address;
    }
    #endregion
}
