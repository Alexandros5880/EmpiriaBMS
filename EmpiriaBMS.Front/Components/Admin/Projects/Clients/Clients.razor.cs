using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Clients;

public partial class Clients
{
    #region Data Grid
    private List<ClientVM> _records = new List<ClientVM>();
    private string _filterString = string.Empty;
    IQueryable<ClientVM>? FilteredItems => _records?.AsQueryable().Where(x => x.FullName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
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

    private void _add()
    {

    }

    private void _edit(ClientVM record)
    {

    }

    private void _delete(ClientVM record)
    {

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
}
