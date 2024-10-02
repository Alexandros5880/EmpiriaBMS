using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Front.Components.KPIS.Helper;


public class GridItem
{
    public string Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int W { get; set; }
    public int H { get; set; }

    [NotMapped]
    public KPIGridItemPosition Position => new KPIGridItemPosition()
    {
        X = X,
        Y = Y,
        W = W,
        H = H
    };
}