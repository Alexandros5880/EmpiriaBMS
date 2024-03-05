namespace EmpiriaBMS.Front.Services;

public class PageCachedService
{
    private List<object> _pageCached = new List<object>();

    public void AddPage(object page)
    {
        RemovePage(page.GetType());
        _pageCached.Add(page);
    }

    public void RemovePage(Type pageType)
    {
        var page = GetPage<Type>();
        _pageCached.Remove(page);
    }

    public T GetPage<T>()
    {
        return (T)_pageCached.FirstOrDefault(p => p.GetType() == typeof(T));
    }

    public Type GetPageType()
    {
        return _pageCached.LastOrDefault()?.GetType();
    }
}
