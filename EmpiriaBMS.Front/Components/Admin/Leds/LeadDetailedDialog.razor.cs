using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin.Leds;

public partial class LeadDetailedDialog : IDialogContentComponent<LeadVM>
{
    [Parameter]
    public LeadVM Content { get; set; }

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private LedDetailed _compoment;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await _compoment.Prepair(Content);
        }
    }

    private async Task SaveAsync()
    {
        Content = await _compoment.SaveAsync();
        if (Content != null)
            await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CloseAsync();
    }

}