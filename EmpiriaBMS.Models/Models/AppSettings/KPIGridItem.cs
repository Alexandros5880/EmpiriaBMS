using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EmpiriaBMS.Front.Components.KPIS.Helper;

public class KPIGridItem : Entity
{
    public bool IsSelected { get; set; }

    // Original property for in-memory usage
    [NotMapped]
    public Type? ComponentType { get; set; }

    // String to store in the database
    public string? ComponentTypeName
    {
        get => ComponentType?.AssemblyQualifiedName;
        set => ComponentType = value != null ? Type.GetType(value) : null;
    }

    [Required]
    public int PositionId { get; set; }
    public KPIGridItemPosition? Position { get; set; }

    /// <summary>
    /// Match Components Properties Names and the value you want to pass
    /// </summary>
    [NotMapped]
    public Dictionary<string, object> Parameters { get; set; } = new();

    // String to store serialized dictionary in the database
    public string ParametersJson
    {
        get => JsonSerializer.Serialize(Parameters);
        set => Parameters = value != null ? JsonSerializer.Deserialize<Dictionary<string, object>>(value) ?? new Dictionary<string, object>() : new Dictionary<string, object>();
    }
}

