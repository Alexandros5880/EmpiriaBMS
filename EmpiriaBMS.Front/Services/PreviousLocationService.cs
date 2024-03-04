namespace EmpiriaBMS.Front.Services;

public class PreviousLocationService
{
    private List<object> _previousLocations = new List<object>();

    public void UpdatePreviousLocation(object page)
    {
        _previousLocations.Add(page);
        if (_previousLocations.Count > 3)
            _previousLocations.RemoveAt(0);
    }

    public object GetPreviousLocation()
    {
        if (_previousLocations.Count == 0) return null;
        return _previousLocations[_previousLocations.Count-1];
    }
}
