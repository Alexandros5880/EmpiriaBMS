namespace EmpiriaBMS.Front.Services;

public class StateService
{
    private Dictionary<Type, bool> _firstRender = new Dictionary<Type, bool>();

    public void UpsertFirstRender(Type pageType, bool FirstRender)
    {
        if (ContainsFirstRender(pageType))
        {
            UpdateFirstRender(pageType, FirstRender);
        }
        else
        {
            AddFirstRender(pageType, FirstRender);
        }
    }

    public void AddFirstRender(Type pageType, bool FirstRender)
    {
        if (!ContainsFirstRender(pageType))
            _firstRender.Add(pageType, FirstRender);
    }

    public void UpdateFirstRender(Type pageType, bool FirstRender)
    {
        if (ContainsFirstRender(pageType))
            _firstRender[pageType] = FirstRender;
    }

    public void RemoveFirstRender(Type pageType)
    {
        _firstRender.Remove(pageType);
    }

    public bool GetFirstRender(Type pageType)
    {
        return _firstRender[pageType];
    }

    public bool ContainsFirstRender(Type pageType)
    {
        return _firstRender.ContainsKey(pageType);
    }

}
