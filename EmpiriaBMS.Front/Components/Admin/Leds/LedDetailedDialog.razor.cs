using EmpiriaBMS.Front.Components.Admin.Contracts;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class LedDetailedDialog : IDialogContentComponent<LedVM>
{
    [Parameter]
    public LedVM Content { get; set; }

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private LedDetailed _compoment;

    private async Task SaveAsync()
    {
        await _compoment.SaveAsync();
    }

    private async Task CancelAsync()
    {
        await Dialog.CloseAsync();
    }

}