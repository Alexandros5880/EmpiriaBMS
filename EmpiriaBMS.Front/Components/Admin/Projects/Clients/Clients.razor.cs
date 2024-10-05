using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.ExportData;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Clients;

public partial class Clients
{
    #region Data Grid
    private List<ClientVM> _records = new List<ClientVM>();
    private string _filterString = string.Empty;
    IQueryable<ClientVM>? FilteredItems => _records?.AsQueryable().Where(x => x.Name.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };

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

    private async Task _getRecords()
    {
        var dtos = await DataProvider.Clients.GetAll();
        _records = Mapper.Map<List<ClientVM>>(dtos);
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
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ClientDetailedDialog>(new ClientVM(), parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ClientVM vm = result.Data as ClientVM;
            var dto = Mapper.Map<ClientDto>(vm);

            // Get Emails
            var emails = Mapping.Mapper.Map<List<EmailDto>>(dto.Emails);
            emails.ForEach(e => e.User = null);
            dto.Emails = null;

            // If Addrees Then Save Address
            if (dto?.Address != null && !(await DataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
                var address = await DataProvider.Address.Add(addressDto);
                dto.AddressId = address.Id;
            }
            else if (dto?.Address != null && (await DataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
                var address = await DataProvider.Address.Update(addressDto);
            }

            var added = await DataProvider.Clients.Add(dto);
            if (added != null)
            {
                emails.ForEach(e => e.UserId = added.Id);
                await DataProvider.Emails.AddRange(emails);
                await _getRecords();
            }
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
            Width = "min(80%, 700px);"
        };

        IDialogReference dialog = await DialogService.ShowDialogAsync<ClientDetailedDialog>(record, parameters);
        DialogResult? result = await dialog.Result;

        if (result.Data is not null)
        {
            ClientVM vm = result.Data as ClientVM;
            var dto = Mapper.Map<ClientDto>(vm);

            // Get Emails
            var emails = Mapping.Mapper.Map<List<EmailDto>>(dto.Emails);
            emails.ForEach(e => e.User = null);
            dto.Emails = null;

            // If Addrees Then Save Address
            if (dto?.Address != null && !(await DataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var addressDto = Mapping.Mapper.Map<AddressDto>(dto.Address);
                var address = await DataProvider.Address.Add(addressDto);
                dto.AddressId = address.Id;
            }
            else if (dto?.Address != null && (await DataProvider.Address.Any(a => a.PlaceId.Equals(dto.Address.PlaceId))))
            {
                var address = await DataProvider.Address.GetByPlaceId(dto.Address.PlaceId);
                dto.AddressId = address.Id;
            }

            await DataProvider.Clients.Update(dto);
            await DataProvider.Emails.RemoveAll(dto.Id);
            await DataProvider.Emails.AddRange(emails);
            await _getRecords();
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
    #endregion

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _getRecords();

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
