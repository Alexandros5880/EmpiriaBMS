using EmpiriaBMS.Front.DefaultComponents;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace EmpiriaBMS.Front.ViewModel.DefaultComponents;
public class PaginatorVM : BNotifyPropertyChanged
{
    private int _pageSize;
    public int PageSize
    {
        get => _pageSize;
        set
        {
            _pageSize = value;
            NotifyPropertyChanged(nameof(PageSize));
        }
    }

    private int _pageIndex;
    public int PageIndex
    {
        get => _pageIndex;
        set
        {
            if (value < 1) return;
            _pageIndex = value;
            NotifyPropertyChanged(nameof(PageIndex));
        }
    }

    private int _recordsCount;
    public int RecordsCount
    {
        get => _recordsCount;
        set
        {
            _recordsCount = value;
            NotifyPropertyChanged(nameof(RecordsCount));
        }
    }

    private int _pagesCounter;
    public int PagesCounter
    {
        get => _pagesCounter;
        set
        {
            _pagesCounter = value;
            NotifyPropertyChanged(nameof(PagesCounter));
        }
    }

    public int FirstDisplayed => PageIndex == 1 ? 1 : PageIndex - 1;

    public int MiddleDisplayed => 
        PageIndex == 1 ? 2 : PageIndex < PagesCounter - 1 ? PageIndex : PagesCounter - 1;

    public int LastDisplayed =>
        PageIndex == 1
            ? PageIndex + 2
            : PageIndex < PagesCounter - 1
                ? PageIndex + 1
                : PagesCounter;

    public PaginatorVM()
    {
        PageSize = 1;
        PageIndex = 1;
        RecordsCount = 0;
        PagesCounter = 0;
    }

    public PaginatorVM(PaginatorVM model)
    {
        PageSize = model.PageSize;
        PageIndex = model.PageIndex;
        RecordsCount = model.RecordsCount;
        PagesCounter = model.PagesCounter;
    }

    public async Task Next(EventCallback func)
    {
        if(PageIndex == PagesCounter) return;
        ++PageIndex;
        await func.InvokeAsync();
    }

    public async Task Previus(EventCallback func)
    {
        if (PageIndex == 0) return;
        --PageIndex;
        await func.InvokeAsync();
    }

    public async Task SetPageIndex(int pageIndex, EventCallback func)
    {
        if (PageIndex >= 0 && PageIndex <= PagesCounter)
        {
            PageIndex = pageIndex;
            await func.InvokeAsync();
        }
    }

    public bool IsFirstPage() => PageIndex == 1;

    public bool IsLastPage() => PageIndex == PagesCounter;

    public bool IsSelected(int pageIndex) => PageIndex == pageIndex;
        
}