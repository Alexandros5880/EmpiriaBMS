using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

using ModelsNameSpace = EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Config;

namespace EmpiriaBMS.Front.Components.Home.Issues;

public partial class Issues : ComponentBase
{
    [Parameter]
    public EventCallback OnSave { get; set; }

    private bool _loading = false;
    private ObservableCollection<IssueVM> _issues = new ObservableCollection<IssueVM>();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _loading = true;
            await _getIssues();
            _loading = false;
            StateHasChanged();
        }
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            List<IssueVM> vms = _issues.ToList();
            List<IssueDto> dtos = Mapper.Map<List<IssueDto>>(vms);
            await DataProvider.Issues.UpdateAll(dtos);
            await OnSave.InvokeAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Issues.HandleValidSubmit(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

    private string _filterString = string.Empty;
    IQueryable<IssueVM> FilteredItems => _issues?.AsQueryable().Where(x => x.ProjectName.Contains(_filterString, StringComparison.CurrentCultureIgnoreCase));
    PaginationState pagination = new PaginationState { ItemsPerPage = 5 };

    private IssueVM _selectedRecord = null;

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

    private void OnRowFocused(FluentDataGridRow<IssueVM> row)
    {
        var r = row;
        var record = r.Item as IssueVM;
        _selectedRecord = record;
    }

    private void _editOnCancel()
    {
        _selectedRecord = null;
    }

    private async Task SaveDetailed()
    {
        await OnSave.InvokeAsync(this);
    }

    private async Task _getIssues()
    {
        try
        {
            var issuesDtos = await DataProvider.Users.GetOpenIssues((int)_sharedAuthData.LogedUser.Id);
            var issuesVms = Mapper.Map<List<IssueVM>>(issuesDtos);

            // TODO: Only For Debug
            var projectId = 145242947;
            var project = await DataProvider.Projects.Get(projectId);

            var discplayRoleId = 593933805;
            var displayRole = await DataProvider.Roles.Get(discplayRoleId);

            var creatorId = 428110306;
            var creator = await DataProvider.Users.Get(creatorId);

            for (int i = 0; i < 10; i++)
            {
                issuesVms.Add(new IssueVM()
                {
                    ComplaintDate = DateTime.Now,
                    ProjectId = projectId,
                    Project = Mapping.Mapper.Map<ModelsNameSpace.Project>(project),
                    DisplayedRoleId = discplayRoleId,
                    DisplayedRole = Mapping.Mapper.Map<Role>(displayRole),
                    CreatorId = creatorId,
                    Creator = Mapping.Mapper.Map<User>(creator),
                    Description = "rwethwrjyht",
                    IsClose = false
                });
            }

            _issues.Clear();
            issuesVms.ForEach(_issues.Add);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception Issues._getIssues(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
        }
    }

}
