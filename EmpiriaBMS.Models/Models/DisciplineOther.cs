using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DisciplineOther : Entity
{
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public int OtherId { get; set; }
    public Other Other { get; set; }
}
