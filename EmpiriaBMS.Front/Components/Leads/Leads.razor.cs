using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.Components.Admin.Leads;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EmpiriaBMS.Front.Components.Leads;

public partial class Leads
{
    #region Data Grid
    private List<LeadVM> _records = new List<LeadVM>();
    private string _filterString = string.Empty;
    IQueryable<LeadVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

    private LeadVM _selectedRecord = new LeadVM();

    private void HandleFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            _filterString = value;
        }
        else if (string.IsNullOrWhiteSpace(_filterString) || string.IsNullOrEmpty(_filterString))
        {
            _filterString = string.Empty;
        }
    }

    private void HandleRowFocus(FluentDataGridRow<LeadVM> row)
    {
        _selectedRecord = row.Item as LeadVM;
    }

    private async Task HandleResultChange(LeadVM context, ChangeEventArgs e)
    {
        if (Enum.TryParse<LeadResult>(e.Value.ToString(), out var newResult))
        {
            context.Result = newResult;
            var dto = Mapper.Map<LeadDto>(context);
            await DataProvider.Leads.Update(dto);
            await _getRecords();
        }
    }

    private async Task _getRecords(LeadResult result = LeadResult.WAITING)
    {
        var dtos = await DataProvider.Leads.GetByResult(result);
        _records = Mapper.Map<List<LeadVM>>(dtos);
    }

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New Record",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<LeadDetailedDialog>(new LeadVM()
        {
            ExpectedDurationDate = DateTime.Now,
            Result = Models.Enum.LeadResult.WAITING
        }, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            LeadVM vm = result.Data as LeadVM;
            var dto = Mapper.Map<LeadDto>(vm);
            await DataProvider.Leads.Add(dto);
            await _getRecords();
        }
    }

    private async Task _edit(LeadVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit Record {record.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(70%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<LeadDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            LeadVM vm = result.Data as LeadVM;
            var dto = Mapper.Map<LeadDto>(vm);
            await DataProvider.Leads.Update(dto);
            await _getRecords();
        }
    }

    private async Task _delete(LeadVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete led {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Leads.Delete(record.Id);
        }

        await dialog.CloseAsync();
        await _getRecords();
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

            _selectedResult = _leadResults.FirstOrDefault(r => r.Text.Equals("WAITING"));
            _resultFilterCombo.Value = _selectedResult.Value;

            StateHasChanged();
        }
    }

    #region Filter Result
    FluentCombobox<(string Value, string Text)> _resultFilterCombo;
    private List<(string Value, string Text)> _leadResults = Enum.GetValues(typeof(LeadResult))
                                                                  .Cast<LeadResult>()
                                                                  .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                                      .First()
                                                                      .GetCustomAttribute<DisplayAttribute>()?
                                                                      .GetName() ?? e.ToString()))
                                                                  .ToList();

    private (string Value, string Text) _selectedResult;

    private async Task _onResultSelectionChanged((string Value, string Text) result)
    {
        _selectedResult = result;
        LeadResult e;
        Enum.TryParse(result.Value, out e);
        await _getRecords(e);
    }
    #endregion

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Leds-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new LedExport(c)).ToList();
        if (data.Count > 0)
        {
            string csvContent = Data.GetCsvContent(data);
            await MicrosoftTeams.DownloadCsvFile(fileName, csvContent);
        }
    }

    private InputFile fileInput;
    private async Task ImportFromCSV(InputFileChangeEventArgs e)
    {
        var file = e.File;
        var filePath = file.Name;
        var fileType = file.ContentType;
        if (fileType?.Equals("text/csv") ?? false)
        {
            try
            {
                Stream stream = file.OpenReadStream();
                List<LedExport> data = await Data.ImportDataFromCsv<LedExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<LeadDto>(vm);
                        var added = await DataProvider.Leads.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<LeadVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Leds.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            }
        }
    }
    private async Task TriggerFileInput()
    {
        var element = fileInput.Element;
        await MicrosoftTeams.TriggerFileInputClick(element);
    }
    #endregion
}