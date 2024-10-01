using EmpiriaBMS.Front.Components.Home.SupportiveWorks;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;

namespace EmpiriaBMS.Front.Components.Home.Deliverables;

public partial class Deliverables
{
    #region Authorization Properties
    public bool assignDesigner => _sharedAuthData.PermissionOrds.Contains(3);
    bool editDeliverable => _sharedAuthData.Permissions.Any(p => p.Ord == 15);
    bool getAllDeliverables => _sharedAuthData.Permissions.Any(p => p.Ord == 10);
    #endregion

    [Parameter]
    public bool Loading { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; }

    private int _disciplineId { get; set; }

    private ObservableCollection<DeliverableVM> _data = new ObservableCollection<DeliverableVM>();

    private List<DeliverableVM> _dataChanged = new List<DeliverableVM>();

    private ObservableCollection<UserVM> _designers = new ObservableCollection<UserVM>();

    private bool _hasDeliverablessSelections = false;

    private DeliverableVM _selectedDeliverable = new DeliverableVM();

    public async Task CheckIfHasSelections()
    {
        if (_disciplineId != 0)
        {
            _hasDeliverablessSelections = await _dataProvider.DeliverablesTypes
                .HasDeliverableTypesSelections(_disciplineId);
        }
    }

    public void ResetSelection() =>
        _selectedDeliverable = null;

    public void SetSelected(DeliverableVM selected)
    {
        if (selected == null || selected.Id == _selectedDeliverable?.Id)
            return;
        _selectedDeliverable = selected;
    }

    private void OnSelect(DeliverableVM draw)
    {
        if (draw == null || draw.Id == _selectedDeliverable?.Id) return;
        _selectedDeliverable = draw;
        StateHasChanged();
    }

    public async Task GetRecords(int discId)
    {
        if (discId == 0)
            return;

        _disciplineId = discId;

        var draws = await _dataProvider.Disciplines.GetDraws(discId, _sharedAuthData.LogedUser.Id, getAllDeliverables);

        _data.Clear();
        foreach (var di in draws)
            _data.Add(Mapper.Map<DeliverableVM>(di));

        StateHasChanged();
    }

    public void ClearRecords()
    {
        _data.Clear();
        _disciplineId = 0;
        StateHasChanged();
    }

    public void ResetChanges() => _dataChanged.Clear();

    private long GetMenHours(int drawingId) =>
        _dataProvider.Deliverables.GetMenHours(drawingId);

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

    private async Task ExportDeliverablesToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Deliverables-{date.ToEuropeFormat()}.csv";
        var data = _data.ToList();
        if (_data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(_data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }

    #region Designers Assign Actions (Deliverable Assign)
    // Add Designer Dialog
    private FluentDialog _addDesignerDialog;
    private bool _isAddDesignerDialogOdepened = false;

    private async Task _getDesigners()
    {
        try
        {
            var defaultRoleId = await GetRoleId("Designer");
            if (defaultRoleId == 0)
                throw new Exception("Exception `Designer` role not exists!");

            var disigners = await _dataProvider.Roles.GetUsers(defaultRoleId);

            if (disigners == null)
                throw new NullReferenceException(nameof(disigners));

            var myDesignersIds = (await _dataProvider.Deliverables.GetDesigners(_selectedDeliverable.Id)).Select(d => d.Id);

            var disignersVM = Mapper.Map<List<UserVM>>(disigners);
            _designers.Clear();
            disignersVM.ForEach(d =>
            {
                d.IsSelected = myDesignersIds.Contains(d.Id);
                _designers.Add(d);
            });
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard._getDesigners(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private async Task OnDeliverableAssignClick(DeliverableVM draw)
    {
        if (!IsWorkingMode) return;
        try
        {
            _selectedDeliverable = draw;
            await _getDesigners();
            StateHasChanged();
            _addDesignerDialog.Show();
            _isAddDesignerDialogOdepened = true;
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Dashboard.OnDeliverableAssignClick(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    public async Task _addDesignerDialogAccept()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;

        var forDeleteIds = _designers.Where(d => d.IsSelected == null || d.IsSelected == false)
                                     .Select(d => d.Id)
                                     .ToList();
        await _dataProvider.Deliverables.RemoveDesigners(_selectedDeliverable.Id, forDeleteIds);

        var forAdd = _designers.Where(d => d.IsSelected == true).ToList();
        var forAddDto = Mapper.Map<List<UserDto>>(forAdd);
        await _dataProvider.Deliverables.AddDesigners(_selectedDeliverable.Id, forAddDto);
    }

    public void _addDesignerDialogCansel()
    {
        _addDesignerDialog.Hide();
        _isAddDesignerDialogOdepened = false;
    }
    #endregion

    #region Add/Edit/Delete Dialog
    // On Add/Edit Deliverable Dialog
    private FluentDialog _addEditDeliverableDialog;
    private bool _isAddEditDeliverableDialogOdepened = false;
    private DeliverableDetailed deliverableCompoment;
    #endregion

    #region Add/Edit/Delete Deliverable Actions
    private void AddDeliverable()
    {
        deliverableCompoment.PrepairForNew();
        _addEditDeliverableDialog.Show();
        _isAddEditDeliverableDialogOdepened = true;
    }

    private void EditDeliverable()
    {
        deliverableCompoment.PrepairForEdit(_selectedDeliverable);
        _addEditDeliverableDialog.Show();
        _isAddEditDeliverableDialogOdepened = true;
    }

    private void CloseAddDeliverableClick()
    {
        if (_isAddEditDeliverableDialogOdepened)
        {
            _addEditDeliverableDialog.Hide();
            _isAddEditDeliverableDialogOdepened = false;
        }
    }

    public async Task _addEditDeliverableDialogAccept()
    {
        await deliverableCompoment.HandleValidSubmit();

        var newDeliverable = deliverableCompoment.GetDeliverable();
        if (_data.Any(d => d.Id == newDeliverable.Id))
            _data.Remove(newDeliverable);

        _data.Insert(0, newDeliverable);
        _data = new ObservableCollection<DeliverableVM>(_data);

        _addEditDeliverableDialog.Hide();
        _isAddEditDeliverableDialogOdepened = false;

        StateHasChanged();
    }

    private void DeleteDeliverable()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedDeliverable.Type.Name}";
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Delete Dialog
    // On Delete Dialog
    private FluentDialog _deleteDialog;
    private bool _isDeleteDialogOdepened = false;
    private string _deleteDialogMsg = "";
    #endregion

    #region Delete Dialog Actions
    private async Task OnDeleteAccept()
    {
        if (_isDeleteDialogOdepened)
        {
            await _dataProvider.Deliverables.Delete(_selectedDeliverable.Id);
            _data.Remove(_selectedDeliverable);
            _selectedDeliverable = null;

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


