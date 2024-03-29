using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Config;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EmpiriaBMS.Front.Components;

public partial class Issues : ComponentBase, IDisposable
{
    private bool disposedValue;

    [Parameter]
    public ObservableCollection<IssueVM> Source { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    protected override void OnInitialized()
    {
        foreach (var item in Source)
        {
            item.PropertyChanged += Item_PropertyChanged;
        }
    }

    private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var item = sender as IssueVM;
        var propertyName = e.PropertyName;
        switch (propertyName)
        {
            case nameof(IssueVM.IsClose):
                break;
            case nameof(IssueVM.Solution):
                item.SolutionDate = DateTime.Now;
                break;
        }
    }

    public async Task HandleValidSubmit()
    {
        try
        {
            List<IssueVM> vms = Source.ToList();
            List<IssueDto> dtos = Mapper.Map<List<IssueDto>>(vms);
            await DataProvider.Issues.UpdateAll(dtos);
            await OnSave.InvokeAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception Issues.HandleValidSubmit() \n Exception: {ex.Message}  ->  \n InnerException: ");
            Console.Write(ex.InnerException.Message);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                foreach (var item in Source)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
