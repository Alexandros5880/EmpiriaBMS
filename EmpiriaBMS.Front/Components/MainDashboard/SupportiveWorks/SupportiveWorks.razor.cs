using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.MainDashboard.SupportiveWorks;

public partial class SupportiveWorks
{
    #region Authorization Properties
    bool editSupportiveWork => _sharedAuthData.Permissions.Any(p => p.Ord == 16);
    #endregion

    [Parameter]
    public bool Loading { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; }

    [Parameter]
    public ProjectVM SelectedProject { get; set; }

    [Parameter]
    public DisciplineVM SelectedDiscipline { get; set; }

    [Parameter]
    public SupportiveWorkVM SelectedSupportiveWork { get; set; }

    [Parameter]
    public bool HasSapportiveWorksSelections { get; set; }

    [Parameter]
    public ObservableCollection<SupportiveWorkVM> Source { get; set; }

    [Parameter]
    public List<SupportiveWorkVM> SourceChanged { get; set; }

    #region Add/Edit/Delete Dialog
    // On Add/Edit Other Dialog
    private FluentDialog _addEditSupportiveWorkDialog;
    private bool _isAddEditSupportiveWorkDialogOdepened = false;
    private SupportiveWorksDetailed supportiveWorkrCompoment;
    #endregion

    private void OnSelect(SupportiveWorkVM doc)
    {
        if (doc == null || doc.Id == SelectedSupportiveWork?.Id) return;
        SelectedSupportiveWork = doc;
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
            await _dataProvider.SupportiveWorks.Delete(SelectedSupportiveWork.Id);
            Source.Remove(SelectedSupportiveWork);
            SelectedSupportiveWork = null;

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
        supportiveWorkrCompoment.PrepairForEdit(SelectedSupportiveWork);
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
        if (Source.Any(d => d.Id == newSupportiveWork.Id))
            Source.Remove(newSupportiveWork);

        Source.Insert(0, newSupportiveWork);
        Source = new ObservableCollection<SupportiveWorkVM>(Source);

        _addEditSupportiveWorkDialog.Hide();
        _isAddEditSupportiveWorkDialogOdepened = false;

        StateHasChanged();
    }

    private void DeleteSupportiveWork()
    {
        _deleteDialogMsg = $"Are you sure you want delete {SelectedSupportiveWork.Type.Name}";
        _deleteDialog.Show();
        _isDeleteDialogOdepened = true;
    }
    #endregion

    #region Export Data
    private async Task ExportSupportiveWorksToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"SupportiveWorks-{date.ToEuropeFormat()}.csv";
        var data = Source.ToList();
        if (Source.Count > 0)
        {
            string csvContent = Data.GetCsvContent(Source);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }
    #endregion
}
