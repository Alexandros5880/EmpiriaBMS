using EmpiriaBMS.Front.ViewModel.Components.Base;

namespace EmpiriaBMS.Front.ViewModel.Components.Projects;
public class ProjectValidModel : BaseVM
{
    private bool _completedValid;
    public bool CompletedValid
    {
        get => _completedValid;
        set
        {
            if (value == _completedValid)
                return;
            _completedValid = value;
            NotifyPropertyChanged(nameof(CompletedValid));
        }
    }

    public ProjectValidModel()
    {
        CompletedValid = true;
    }

    public bool Validate(ProjectVM model, string propertyName = null)
    {
        if (string.IsNullOrEmpty(propertyName)) return _validateAll(model);

        switch (propertyName)
        {
            case nameof(ProjectVM.Completed):
                var val = (int)model.GetType().GetProperty(nameof(ProjectVM.Completed)).GetValue(model, null);
                CompletedValid = val >= 0 && val <= 100;
                return CompletedValid;
            default:
                return true;
        }
    }

    private bool _validateAll(ProjectVM model)
    {
        return true;
    }
}