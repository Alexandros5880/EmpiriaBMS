using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.General;

public partial class UniqueTypeForm : IDialogContentComponent<ITypeVM>
{
    [Parameter]
    public ITypeVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private async Task SaveAsync()
    {
        var valid = Validate();
        if (!valid) return;

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

    #region Validation
    private bool validName = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validName = !string.IsNullOrEmpty(Content.Name);

            return validName;
        }
        else
        {
            validName = true;

            switch (fieldname)
            {
                case "Name":
                    validName = !string.IsNullOrEmpty(Content.Name);
                    return validName;
                default:
                    return true;
            }

        }
    }
    #endregion
}
