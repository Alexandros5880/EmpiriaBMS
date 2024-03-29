using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using System.Text.Json;
using EmpiriaBMS.Front.ViewModel.Components;
using System.ComponentModel;
using EmpiriaBMS.Front.Components.General;

namespace EmpiriaBMS.Front.Components;

public partial class IssueDetailed : ComponentBase, IDisposable
{
    private bool disposedValue;

    private ProjectVM _project;
    [Parameter]
    public ProjectVM Project
    {
        get => _project;
        set
        {
            if (value != null)
            {
                _project = value;
                UserDto u = Mapping.Mapper.Map<UserDto>(_project.Customer);
                _customer = Mapper.Map<UserVM>(u);
            }
        }
    }

    [Parameter]
    public bool DisplayBaseInfo { get; set; }

    private UserVM _customer;

    private IssueVM _issue = new IssueVM()
    {
        ComplaintDate = DateTime.Now,
        SolutionDate = DateTime.Now,
        VerificationDate = DateTime.Now
    };

    SignaturePad verificatorSignature;
    SignaturePad pMSignature;

    public void Refresh()
    {
        _issue = new IssueVM()
        {
            ComplaintDate = DateTime.Now,
            SolutionDate = DateTime.Now,
            VerificationDate = DateTime.Now
        };
        _issue.PropertyChanged += _issuePropertyChanged;
        StateHasChanged();
    }

    private void _issuePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_issue.IsClose):
                bool isClosed = (sender as IssueVM).IsClose;
                _issue.SolutionDate = isClosed ? DateTime.Now : _issue.SolutionDate;
                break;
        }
    }

    public async Task HandleValidSubmit()
    {
        // TODO: Setup Visible Users
        var parentRole = _sharedAuthData.LoggedUserParentRole;
        _issue.RoleId = parentRole.Id;
        _issue.VerificatorSignature = verificatorSignature != null ? await verificatorSignature.GetImageData() : null;
        _issue.PMSignature = pMSignature != null ? await pMSignature.GetImageData() : null;
        _issue.ProjectId = _project.Id;
        _issue.CreatorId = _sharedAuthData.LogedUser.Id;
        _issue.IsClose = false;

        try
        {
            var dto = Mapper.Map<IssueDto>(_issue);
            await DataProvider.Issues.Add(dto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception IssueDetailed.HandleValidSubmit() \"await DataProvider.Issues.Add(dto);\" \n Exception: {ex.Message}  ->  \n InnerException: ");
            Console.Write(ex.InnerException.Message);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _issue.PropertyChanged -= _issuePropertyChanged;
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
