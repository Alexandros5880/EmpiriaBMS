using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.JSInterop;
using NuGet.Packaging;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components.Admin.Projects.Issues;

public partial class IssuesDetailedDialog : IDialogContentComponent<IssueVM>
{
    [Parameter]
    public IssueVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private async Task SaveAsync() =>
        await Dialog.CloseAsync(Content);

    private async Task CancelAsync() =>
        await Dialog.CancelAsync();
}
