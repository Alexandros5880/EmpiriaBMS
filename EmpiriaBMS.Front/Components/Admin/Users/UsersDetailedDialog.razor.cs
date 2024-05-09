using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using System;
using System.Security.Policy;
using System.Text.RegularExpressions;
using static Microsoft.Fast.Components.FluentUI.Emojis.Objects.Color.Default;

namespace EmpiriaBMS.Front.Components.Admin.Users;

public partial class UsersDetailedDialog : IDialogContentComponent<UserVM>
{
    [Parameter]
    public UserVM Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    private async Task SaveAsync()
    {
        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

}