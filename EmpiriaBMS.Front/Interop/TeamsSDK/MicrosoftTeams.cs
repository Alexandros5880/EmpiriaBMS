using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.ViewModel.DefaultComponents;
using Microsoft.AspNetCore.Components;
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

    public Task NavigateToAdmin(string url, string objectId)
    {
        return InvokeVoidAsync("navigateToAdmin", url, objectId);
    }

    public Task RegisterGlobalMouseWheelEvent(DotNetObjectReference<TimeInput> objRef, string Id)
    {
        return InvokeVoidAsync("registerGlobalMouseWheelEvent", objRef, Id);
    }

    #region Cookies
    public async Task SetCookie(string key, string value)
    {
        await InvokeVoidAsync("setCooke", key, value);
    }

    public async Task<string> GetCookie(string key)
    {
        return await InvokeAsync<string>("getCooke", key);
    }
    #endregion

    #region Canvas
    public async Task InitializeCanvas(ElementReference canvasRef)
    {
        await InvokeVoidAsync("initializeCanvas", canvasRef);
    }

    public async Task clearCanvas(ElementReference canvasRef)
    {
        await InvokeVoidAsync("clearCanvas", canvasRef);
    }

    public async Task<byte[]> GetCanvasImageData(ElementReference canvasRef)
    {
        return await InvokeAsync<byte[]>("getCanvasImageData", canvasRef);
    }
    #endregion

    #region Google Maps
    public async Task DisplayAddress(string mapElementId, string[] address)
    {
        await InvokeVoidAsync("displayAddress", mapElementId, address);
    }

    public async Task OpenDirectionsInNewWindow(string url)
    {
        await InvokeVoidAsync("openDirectionsInNewWindow", url);
    }

    // Google Maps Autocomplete
    public async Task InitializeAutocomplete(string inputElementId)
    {
        await InvokeVoidAsync("initializeAutocomplete", inputElementId);
    }
    #endregion

    #region Download Document
    public async Task DownloadFile(DocumentDto doc)
    {
        await InvokeVoidAsync("downloadFile", doc.FileName, doc.ContentType, Convert.ToBase64String(doc.Content));
    }
    #endregion

    #region Pick Folder Path
    public async Task<string> PickFolderPath()
    {
        return await InvokeAsync<string>("pickFolderPath");
    }
    #endregion

    #region Download CSV File
    public async Task DownloadCsvFile(string filenName, string content)
    {
        await InvokeVoidAsync("downloadCsvFile", filenName, content);
    }
    #endregion

    #region Element Click
    public async Task TriggerFileInputClick(ElementReference? element)
    {
        if (element != null)
            await InvokeVoidAsync("triggerFileInputClick", element);
    }
    #endregion
}