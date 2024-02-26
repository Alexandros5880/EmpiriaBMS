using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ManHour : Entity
{
    public int? DrawingId { get; set; }
    public Drawing? Drawing { get; set; }

    public int? OtherId { get; set; }
    public Other? Other { get; set; }

    public int? DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public long Hours { get; set; }
}
