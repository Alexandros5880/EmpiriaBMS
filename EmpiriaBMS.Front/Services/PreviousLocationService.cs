namespace EmpiriaBMS.Front.Services;

public class PreviousLocationService
{
    private string _previousLocation;

    public void UpdatePreviousLocation(string location)
    {
        _previousLocation = location;
    }

    public string GetPreviousLocation()
    {
        return _previousLocation;
    }
}
