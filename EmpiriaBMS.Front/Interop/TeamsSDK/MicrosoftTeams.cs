using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using Microsoft.JSInterop;

namespace EmpiriaBMS.Front.Interop.TeamsSDK;

public class MicrosoftTeams : InteropModuleBase
{
    protected override string ModulePath => "./js/TeamsJsBlazorInterop.js";

    public MicrosoftTeams(IJSRuntime jsRuntime) : base(jsRuntime) { }

    public Task InitializeAsync()
    {
        return InvokeVoidAsync("initializeAsync");
    }

    public Task<TeamsContext> GetTeamsContextAsync()
    {
        return InvokeAsync<TeamsContext>("getContextAsync");
    }

    public Task RegisterOnSaveHandlerAsync(TeamsInstanceSettings settings)
    {
        return InvokeVoidAsync("registerOnSaveHandler", settings);
    }

    public Task<bool> IsInTeams()
    {
        try
        {
            return InvokeAsync<bool>("inTeams");
        }
        catch (JSException)
        {
            return Task.FromResult(false);
        }
    }

    public Task<ScreenSize> GetScreenSize()
    {
        return InvokeAsync<ScreenSize>("getScreenSize");
    }

    public Task NavigateToAdmin(string url, string objectId, string roleId)
    {
        return InvokeVoidAsync("navigateToAdmin", url, objectId, roleId);
    }
}