using EmpiriaBMS.Front.DefaultComponents;
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

    public PaginatorVM()
    {
        PageSize = 5;
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

    public async Task Next(Func<Task> func)
    {
        if(PageIndex == PagesCounter) return;
        ++PageIndex;
        await func();
    }

    public async Task Previus(Func<Task> func)
    {
        if (PageIndex == 0) return;
        --PageIndex;
        await func();
    }

    public async Task SetPageIndex(int pageIndex, Func<Task> func)
    {
        if (PageIndex >= 0 && PageIndex <= PagesCounter)
        {
            PageIndex = pageIndex;
            await func();
        }
    }

    public bool IsFirstPage() => PageIndex == 1;

    public bool IsLastPage() => PageIndex == PagesCounter;

    public bool IsSelected(int pageIndex) => PageIndex == pageIndex;

    public int CountPages() => PagesCounter;
}