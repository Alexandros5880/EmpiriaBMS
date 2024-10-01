using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Home.SupportiveWorks;

public partial class SupportiveWorks
{
    private bool _loading = false;

    #region Authorization Properties
    bool editSupportiveWork => _sharedAuthData.Permissions.Any(p => p.Ord == 16);
    #endregion

    [Parameter]
    public bool IsWorkingMode { get; set; }

    private int _disciplineId { get; set; }

    private ObservableCollection<SupportiveWorkVM> _data = new ObservableCollection<SupportiveWorkVM>();

    private List<SupportiveWorkVM> _dataChanged = new List<SupportiveWorkVM>();

    private bool _hasSapportiveWorksSelections = false;

    private SupportiveWorkVM _selectedSupportiveWork = new SupportiveWorkVM();

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        await GetRecords(_disciplineId);

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task CheckIfHasSelections()
    {
        if (_disciplineId != 0)
        {
            _hasSapportiveWorksSelections = await _dataProvider.SupportiveWorksTypes
                .HasOtherTypesSelections(_disciplineId);
        }
    }

    public void ResetSelection() =>
        _selectedSupportiveWork = null;

    public void SetSelected(SupportiveWorkVM selected)
    {
        if (selected == null || selected.Id == _selectedSupportiveWork?.Id)
            return;
        _selectedSupportiveWork = selected;
    }

    public async Task GetRecords(int discId)
    {
        if (discId == 0)
            return;

        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        _disciplineId = discId;

        var others = await _dataProvider.Disciplines.GetOthers(discId, _sharedAuthData.LogedUser.Id, true);

        _data.Clear();
        foreach (var di in others)
            _data.Add(Mapper.Map<SupportiveWorkVM>(di));

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    public void ClearRecords()
    {
        _data.Clear();
        _disciplineId = 0;
        StateHasChanged();
    }

    public void ResetChanges() => _dataChanged.Clear();

    #region Add/Edit/Delete Dialog
    // On Add/Edit Other Dialog
    private FluentDialog _addEditSupportiveWorkDialog;
    private bool _isAddEditSupportiveWorkDialogOdepened = false;
    private SupportiveWorksDetailed supportiveWorkrCompoment;
    #endregion

    private void OnSelect(SupportiveWorkVM doc)
    {
        if (doc == null || doc.Id == _selectedSupportiveWork?.Id) return;
        _selectedSupportiveWork = doc;
        StateHasChanged();
    }
    
    private long GetMenHours(int otherId) =>
        _dataProvider.SupportiveWorks.GetMenHours(otherId);

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
            await _dataProvider.SupportiveWorks.Delete(_selectedSupportiveWork.Id);
            _data.Remove(_selectedSupportiveWork);
            _selectedSupportiveWork = null;

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

    #region Add/Edit/Delete SupportiveWorks Actions
    private void AddSupportiveWork()
    {
        supportiveWorkrCompoment.PrepairForNew();
        _addEditSupportiveWorkDialog.Show();
        _isAddEditSupportiveWorkDialogOdepened = true;
    }

    private void EditSupportiveWork()
    {
        supportiveWorkrCompoment.PrepairForEdit(_selectedSupportiveWork);
        _addEditSupportiveWorkDialog.Show();
        _isAddEditSupportiveWorkDialogOdepened = true;
    }

    private void CloseAddSupportiveWorkClick()
    {
        if (_isAddEditSupportiveWorkDialogOdepened)
        {
            _addEditSupportiveWorkDialog.Hide();
            _isAddEditSupportiveWorkDialogOdepened = false;
        }
    }

    public async Task _addEditSupportiveWorkDialogAccept()
    {
        await supportiveWorkrCompoment.HandleValidSubmit();

        var newSupportiveWork = supportiveWorkrCompoment.GetSupportiveWork();
        if (_data.Any(d => d.Id == newSupportiveWork.Id))
            _data.Remove(newSupportiveWork);

        _data.Insert(0, newSupportiveWork);
        _data = new ObservableCollection<SupportiveWorkVM>(_data);

        _addEditSupportiveWorkDialog.Hide();
        _isAddEditSupportiveWorkDialogOdepened = false;

        StateHasChanged();
    }

    private void DeleteSupportiveWork()
    {
        _deleteDialogMsg = $"Are you sure you want delete {_selectedSupportiveWork.Type.Name}";
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Export Data
    private async Task ExportSupportiveWorksToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"SupportiveWorks-{date.ToEuropeFormat()}.csv";
        var data = _data.ToList();
        if (_data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(_data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
