using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using EmpiriaBMS.Models.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;
using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace EmpiriaBMS.Front.Components.Home.Clients;

public partial class Clients
{
    [Parameter]
    public EventCallback<ClientVM> OnResultChanged { get; set; }

    [Parameter]
    public bool IsWorkingMode { get; set; } = false;

    private bool _loading = false;

    #region Data Grid
    private List<ClientVM> _records = new List<ClientVM>();
    private string _filterString = string.Empty;
    IQueryable<ClientVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private ClientVM _selectedRecord = new ClientVM();

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

    private void HandleRowFocus(FluentDataGridRow<ClientVM> row)
    {
        _selectedRecord = row.Item as ClientVM;
    }

    private async Task _getRecords(ClientResult result = ClientResult.WAITING)
    {
        var dtos = await DataProvider.Clients.GetByResult(result);
        _records = Mapper.Map<List<ClientVM>>(dtos);
    }

    private async Task _add()
    {
        DialogParameters parameters = new()
        {
            Title = $"New Client",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(max(50vw, 500px), 1000px)",
            Height = "min(max(80vh, 500px), 1000px)"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ClientDetailedDialog>(new ClientVM()
        {
            ExpectedDurationDate = DateTime.Now,
            Result = Models.Enum.ClientResult.WAITING
        }, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ClientVM vm = result.Data as ClientVM;
            _records.Add(vm);
        }
    }

    private async Task _edit(ClientVM record)
    {
        DialogParameters parameters = new()
        {
            Title = $"Edit {record.Name}",
            PrimaryActionEnabled = true,
            SecondaryActionEnabled = true,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            TrapFocus = true,
            Modal = true,
            PreventScroll = true,
            Width = "min(max(50vw, 500px), 1000px)",
            Height = "min(max(70vh, 700px), 1000px)"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ClientDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ClientVM vm = result.Data as ClientVM;
            _records.Add(vm);
        }
    }

    private async Task _delete(ClientVM record)
    {
        var dialog = await DialogService.ShowConfirmationAsync($"Are you sure you want to delete the client {record.Name}?", "Yes", "No", "Deleting record...");

        DialogResult result = await dialog.Result;

        if (!result.Cancelled)
        {
            await DataProvider.Clients.Delete(record.Id);
        }

        await dialog.CloseAsync();
        await _getRecords();
    }

    private async Task HandleResultChange(ClientVM context, ChangeEventArgs e)
    {
        if (Enum.TryParse<ClientResult>(e.Value.ToString(), out var newResult))
        {
            context.Result = newResult;
            var dto = Mapper.Map<ClientDto>(context);
            await DataProvider.Clients.Update(dto);
            await _getRecords();

            await OnResultChanged.InvokeAsync(context);
        }
    }
    #endregion

    #region Filter
    FluentCombobox<(string Value, string Text)> _resultFilterCombo;
    

    private List<(string Value, string Text)> _clientsResults = Enum.GetValues(typeof(ClientResult))
                                                                  .Cast<ClientResult>()
                                                                  .Select(e => (e.ToString(), e.GetType().GetMember(e.ToString())
                                                                      .First()
                                                                      .GetCustomAttribute<DisplayAttribute>()?
                                                                      .GetName() ?? e.ToString()))
                                                                  .ToList();

    private (string Value, string Text) _selectedResult;
    private string _selectedResultValue;

    private async Task _onResultSelectionChanged((string Value, string Text) result)
    {
        _selectedResult = result;
        ClientResult e;
        Enum.TryParse(result.Value, out e);
        await _getRecords(e);
    }

    public void SetSelectedOption(string value)
    {
        var selectedOption = _clientsResults.FirstOrDefault(item => item.Value == value);
        if (selectedOption != default)
        {
            _selectedResultValue = selectedOption.Value;
        }
    }
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            if (_loading == false)
            {
                _loading = true;
                StateHasChanged();
            }

            var resultFilter = ClientResult.WAITING;
            _selectedResult = resultFilter.ToTuple();
            SetSelectedOption(_selectedResult.Value);
            await _getRecords();

            if (_loading == true)
            {
                _loading = false;
                StateHasChanged();
            }
        }
    }

    public async Task Refresh()
    {
        if (_loading == false)
        {
            _loading = true;
            StateHasChanged();
        }

        await _getRecords();

        if (_loading == true)
        {
            _loading = false;
            StateHasChanged();
        }
    }

    #region Import/Export Data
    private async Task ExportToCSV()
    {
        var date = DateTime.Today;
        var fileName = $"Clients-{date.ToEuropeFormat()}.csv";
        var data = FilteredItems.Select(c => new ClientExport(c)).ToList();
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
                List<ClientExport> data = await Data.ImportDataFromCsv<ClientExport>(stream);
                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var vm = item.Get();
                        var dto = Mapper.Map<ClientDto>(vm);
                        var added = await DataProvider.Clients.Add(dto);
                        if (added == null)
                            continue;
                        var addedDto = Mapper.Map<ClientVM>(added);
                        _records.Add(addedDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Exception Clients.ImportFromCSV(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
