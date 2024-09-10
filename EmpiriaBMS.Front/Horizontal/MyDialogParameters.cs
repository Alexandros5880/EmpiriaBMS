using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Horizontal;

public class MyDialogParameters : DialogParameters
{
    public bool DisplayProject { get; set; } = false;
    public bool IsWorkingMode { get; set; } = false;
}

/// <summary>
/// Parameters for a dialog.
/// </summary>
public class MyDialogParameters<TContent> : MyDialogParameters, IDialogParameters<TContent>
    where TContent : class
{
    /// <summary>
    /// Content to pass to and from the dialog.
    /// </summary>
    public TContent Content { get; set; } = default!;
}
