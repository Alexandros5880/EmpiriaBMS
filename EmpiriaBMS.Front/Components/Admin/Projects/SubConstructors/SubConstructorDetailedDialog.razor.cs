using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Projects.SubConstructors;

public partial class SubConstructorDetailedDialog : IDialogContentComponent<SubConstructorVM>
{
    [Parameter]
    public SubConstructorVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private SubConstructorDetailed _compoment;

    private async Task SaveAsync()
    {
        await _compoment.SaveAsync();

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

}