using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.Components.KPIS.Helper;

public class KPIGridItemPosition : Entity
{
    [Required]
    public int KPIGridItemId { get; set; }
    public KPIGridItem? KPIGridItem { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    public int W { get; set; }
    public int H { get; set; }
}

