using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Clients;

public partial class ClientDetailedDialog : IDialogContentComponent<ClientVM>
{
    [Parameter]
    public ClientVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private ClientDetailed _compoment;

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
        var valid = _compoment.Validate();
        if (!valid) return;

        await _compoment.SaveAsync();

        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

}