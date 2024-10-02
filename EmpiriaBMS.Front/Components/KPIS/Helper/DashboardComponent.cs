namespace EmpiriaBMS.Front.Components.KPIS.Helper;

public class DashboardComponent
{
    public string Id { get; set; }
    public Type ComponentType { get; set; }

    /// <summary>
    /// Match Compoments Properties Names and the value you want to pass
    /// </summary>
    public Dictionary<string, object> Parameters { get; set; } = new();
}
