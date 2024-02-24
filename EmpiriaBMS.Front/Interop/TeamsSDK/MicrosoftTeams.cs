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

    public Task ApplyTimeMask(string elementId, string minTime, string maxTime)
    {
        ApplyTimeInputValidationParameters param = new ApplyTimeInputValidationParameters()
        {
            ElementId = elementId,
            MinTime = minTime,
            MaxTime = maxTime
        };
        return InvokeVoidAsync("applyTimeMask", param);
    }




    // Parameter Class
    protected class ApplyTimeInputValidationParameters
    {
        public string ElementId { get; set; }
        public string MinTime { get; set; }
        public string MaxTime { get; set; }
    }
}