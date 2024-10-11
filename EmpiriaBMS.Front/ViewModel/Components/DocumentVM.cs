using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components;

public class DocumentVM : BaseVM
{
    private string _fileName;
    public string FileName
    {
        get => _fileName;
        set
        {
            if (value == _fileName)
                return;
            _fileName = value;
            NotifyPropertyChanged(nameof(FileName));
        }
    }

    private string _contentType;
    public string ContentType
    {
        get => _contentType;
        set
        {
            if (value == _contentType)
                return;
            _contentType = value;
            NotifyPropertyChanged(nameof(ContentType));
        }
    }

    private byte[] _content;
    public byte[] Content
    {
        get => _content;
        set
        {
            if (value == _content)
                return;
            _content = value;
            NotifyPropertyChanged(nameof(Content));
        }
    }

    private long _issueId;
    public long IssueId
    {
        get => _issueId;
        set
        {
            if (value == _issueId)
                return;
            _issueId = value;
            NotifyPropertyChanged(nameof(IssueId));
        }
    }

    private IssueVM _issue;
    public IssueVM Issue
    {
        get => _issue;
        set
        {
            if (value == _issue)
                return;
            _issue = value;
            NotifyPropertyChanged(nameof(Issue));
        }
    }
}
