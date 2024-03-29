using Microsoft.AspNetCore.Components;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using System.Text.Json;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.Components.General;
using System.ComponentModel;

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
        _issue.VerificatorSignature = await verificatorSignature.GetImageData();
        _issue.PMSignature = await pMSignature.GetImageData();
        _issue.ProjectId = _project.Id;

        // TODO: Validate And Save Complain
        if (_issue.ComplaintDate <= DateTime.Now.AddDays(-1) || _issue.ComplaintDate == null)
        {

        }
        if (string.IsNullOrEmpty(_issue.About))
        {

        }
        if (string.IsNullOrEmpty(_issue.Description))
        {

        }
        if (string.IsNullOrEmpty(_issue.Solution))
        {

        }
        if (_issue.SolutionDate <= DateTime.Now.AddDays(-1) || _issue.SolutionDate == null)
        {

        }
        if (string.IsNullOrEmpty(_issue.Evaluation))
        {

        }
        if (string.IsNullOrEmpty(_issue.Verification))
        {

        }
        if (_issue.VerificationDate <= DateTime.Now.AddDays(-1) || _issue.VerificationDate == null)
        {

        }
        if (_issue.VerificatorSignature.Length == 0)
        {

        }
        if (_issue.PMSignature.Length == 0)
        {

        }

        await DataProvider.Issues.Add(Mapper.Map<IssueDto>(_issue));
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
