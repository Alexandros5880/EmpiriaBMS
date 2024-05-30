using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Contracts;

public partial class ContractDetailedDialog : IDialogContentComponent<ContractVM>
{
    [Parameter]
    public ContractVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private ContractDetailed _compoment;

    private async Task SaveAsync()
    {
        await _compoment.SaveAsync();
        await Dialog.CloseAsync(Content);
    }
        

    private async Task CancelAsync()
    {
        await Dialog.CloseAsync();
    }
    
}