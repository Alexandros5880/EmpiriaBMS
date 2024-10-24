﻿using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;

namespace EmpiriaBMS.Front.Components.Home.Issues;

public partial class IssueRequestDetailed : ComponentBase, IDisposable
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
            }
        }
    }

    private IssueVM _issue = new IssueVM()
    {
        ComplaintDate = DateTime.Now,
        SolutionDate = DateTime.Now,
        VerificationDate = DateTime.Now
    };

    private List<DocumentVM> _documents = new List<DocumentVM>();

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

    private void _issuePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_issue.IsClose):
                bool isClosed = (sender as IssueVM).IsClose;
                _issue.SolutionDate = isClosed ? DateTime.Now : _issue.SolutionDate;
                break;
        }
    }

    private async Task HandleFileUploadDoc(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles())
        {
            // Read file content
            using var stream = file.OpenReadStream();
            var buffer = new byte[file.Size];
            await stream.ReadAsync(buffer, 0, (int)file.Size);

            // Create Documents
            var document = new DocumentVM()
            {
                FileName = file.Name,
                ContentType = file.ContentType,
                Content = buffer,
                IssueId = _issue.Id
            };
            _documents.Add(document);
        }
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            var parentRole = _sharedAuthData.LoggedUserParentRole;
            _issue.DisplayedRoleId = parentRole.Id;
            _issue.ProjectId = _project.Id;
            _issue.CreatorId = _sharedAuthData.LogedUser.Id;
            _issue.IsClose = false;

            var dto = Mapper.Map<IssueDto>(_issue);
            var documentsDtos = Mapper.Map<List<DocumentDto>>(_documents);
            await DataProvider.Issues.Add(dto, documentsDtos);
        }
        catch (NullReferenceException nex)
        {
            Logger.LogError($"Exception IssueDetailed.HandleValidSubmit(): {nex.Message}, \n Inner Exception: {nex.InnerException}");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Exception IssueDetailed.HandleValidSubmit(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
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
