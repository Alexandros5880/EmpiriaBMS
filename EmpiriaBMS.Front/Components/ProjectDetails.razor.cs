using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;
public partial class ProjectDetails : IDisposable
{
    private bool disposedValue;

    [Parameter]
    public ProjectVM Project { get; set; }

    [Parameter]
    public Action<int> PropertyChanged { get; set; }

    protected override void OnParametersSet()
    {
        if (Project != null)
        {
            Project.PropertyChanged -= _projectChanged;
            Project.PropertyChanged += _projectChanged;
        }
    }

    private void _projectChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var id = (int)sender.GetType().GetProperty(nameof(ProjectVM.Id)).GetValue(sender);
        if (id == null)
            return;
        PropertyChanged(id);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Project.PropertyChanged -= _projectChanged;
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
