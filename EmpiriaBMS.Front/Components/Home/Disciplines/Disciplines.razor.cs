using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using DevComp = EmpiriaBMS.Front.Components.Home.Deliverables;
using DiscComp = EmpiriaBMS.Front.Components.Home.Disciplines;
using SWComp = EmpiriaBMS.Front.Components.Home.SupportiveWorks;

namespace EmpiriaBMS.Front.Components.Home.Disciplines;

public partial class Disciplines
{
    private bool _loading = false;

    #region Authorization Properties
    bool editDiscipline => _sharedAuthData.Permissions.Any(p => p.Ord == 14);
    bool getAllDisciplines => _sharedAuthData.Permissions.Any(p => p.Ord == 9);
    public bool assignEngineer => _sharedAuthData.PermissionOrds.Contains(4);
    #endregion

    [Parameter]
    public bool IsWorkingMode { get; set; }

    [Parameter]
    public EventCallback<int> OnSelect { get; set; }

    private DisciplineVM _selectedDiscipline { get; set; }

    public int _projectId { get; set; }

    #region Dialogs
    // Add Engineer Dialog
    private FluentDialog _addEngineerDialog;
    private bool _isAddEngineerDialogOdepened = false;

    // On Add/Edit Discipline Dialog
    private FluentDialog _addEditDisciplineDialog;
    private bool _isAddEditDisciplineDialogOdepened = false;
    private DisciplineDetailed disciplineCompoment;

    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;
    private string _deleteDialogMsg = "";
    #endregion

    private ObservableCollection<DisciplineVM> _data = new ObservableCollection<DisciplineVM>();

    private List<DisciplineVM> _dataChanged = new List<DisciplineVM>();

    private bool _hasDisciplinesSelections = false;

    private ObservableCollection<UserVM> _engineers = new ObservableCollection<UserVM>();

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        await GetRecords(_projectId);

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task CheckIfHasSelections()
    {
        if (_projectId != 0)
        {
            _hasDisciplinesSelections = 
                await _dataProvider.DisciplinesTypes.HasDisciplineTypesSelections(_projectId);
        }
    }

    public void ResetSelection() =>
        _selectedDiscipline = null;

    public void SetSelected(DisciplineVM selected)
    {
        if (selected == null || selected.Id == _selectedDiscipline?.Id)
            return;
        _selectedDiscipline = selected;
    }

    public async Task GetRecords(int projId)
    {
        if (projId == 0)
            return;

        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        _projectId = projId;

        var disciplines = await _dataProvider.Projects.GetDisciplines(projId, _sharedAuthData.LogedUser.Id, getAllDisciplines);


        _data.Clear();
        foreach (var di in disciplines)
            _data.Add(Mapper.Map<DisciplineVM>(di));

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    public void ClearRecords()
    {
        _data.Clear();
        StateHasChanged();
    }

    public void ResetChanges() => _dataChanged.Clear();

    private async Task OnSelectDiscipline(int disciplineId)
    {
        if (disciplineId == 0 || disciplineId == _selectedDiscipline?.Id)
            return;

        _selectedDiscipline = _data.FirstOrDefault(d => d.Id == disciplineId);

        await CheckIfHasSelections();

        await OnSelect.InvokeAsync(disciplineId);

        StateHasChanged();
    }

    private long GetMenHours(int disciplineId) =>
        _dataProvider.Disciplines.GetMenHours(disciplineId);

    private async Task<int> GetRoleId(string roleName)
    {
        try
        {
            var role = await _dataProvider.Roles.Get(roleName);
            return role?.Id ?? 0;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.GetRoleId(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return 0;
        }
    }

    private async Task _getEngineers()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Engineer");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Engineer` role not exists!");

            var engineers = await _dataProvider.Roles.GetUsers(defaultRoleId);

            if (engineers == null)
                throw new NullReferenceException(nameof(engineers));

            var myEngineersIds = (await _dataProvider.Disciplines.GetEngineers(_selectedDiscipline.Id)).Select(d => d.Id);

            var engineersVM = Mapper.Map<List<UserVM>>(engineers);
            _engineers.Clear();
            engineersVM.ForEach(d =>
            {
                d.IsSelected = myEngineersIds.Contains(d.Id);
                _engineers.Add(d);
            });
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._getEngineers(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private async Task ExportDisciplinesToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Disciplines-{date.ToEuropeFormat()}.csv";
        var data = _data.ToList();
        if (_data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(_data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }

    #region Engineers Assign Actions (Discipline Assign)
    private async Task OnDesciplineAssignClick(DisciplineVM discipline)
    {
        if (!IsWorkingMode) return;
        try
        {
            _selectedDiscipline = discipline;
            await _getEngineers();
            StateHasChanged();
            _addEngineerDialog.Show();
            _isAddEngineerDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.OnDesciplineAssignClick(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    public async Task _addEngineerDialogAccept()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;

        var forDeleteIds = _engineers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await _dataProvider.Disciplines.RemoveEngineers(_selectedDiscipline.Id, forDeleteIds);

        var forAdd = _engineers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await _dataProvider.Disciplines.AddEngineers(_selectedDiscipline.Id, forAddDto);
    }

    public void _addEngineerDialogCansel()
    {
        _addEngineerDialog.Hide();
        _isAddEngineerDialogOdepened = false;
    }
    #endregion

    #region Add/Edit/Delete Discipline Actions
    private async Task AddDiscipline()
    {
        await disciplineCompoment.PrepairForNew();
        _addEditDisciplineDialog.Show();
        _isAddEditDisciplineDialogOdepened = true;
    }

    private async Task EditDiscipline()
    {
        await disciplineCompoment.PrepairForEdit(_selectedDiscipline);
        _addEditDisciplineDialog.Show();
        _isAddEditDisciplineDialogOdepened = true;
    }

    private void CloseAddDisciplineClick()
    {
        if (_isAddEditDisciplineDialogOdepened)
        {
            _addEditDisciplineDialog.Hide();
            _isAddEditDisciplineDialogOdepened = false;
        }
    }

    public async Task _addEditDisciplineDialogAccept()
    {
        await disciplineCompoment.HandleValidSubmit();

        var newDiscipline = disciplineCompoment.GetDiscipline();

        if (newDiscipline == null)
            return;

        if (_data.Any(d => d.Id == newDiscipline.Id))
            _data.Remove(newDiscipline);

        _data.Insert(0, newDiscipline);
        _data = new ObservableCollection<DisciplineVM>(_data);

        _addEditDisciplineDialog.Hide();
        _isAddEditDisciplineDialogOdepened = false;

        StateHasChanged();
    }

    private void DeleteDiscipline()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedDiscipline.Type.Name}";
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            await _dataProvider.Disciplines.Delete(_selectedDiscipline.Id);
            _data.Remove(_selectedDiscipline);
            _selectedDiscipline = null;

            _deleteDialogMsg = "";
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;

            StateHasChanged();
        }
    }

    private void OnDeleteClose()
    {
        if (_isDeleteDialogOdepened)
        {
            _deleteDialogMsg = "";
            _deleteDialog.Hide();
            _isDeleteDialogOdepened = false;
        }
    }
    #endregion
}
