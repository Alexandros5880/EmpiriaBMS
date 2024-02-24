using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DisciplineDraw : Entity
{
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public int DrawId { get; set; }
    public Draw Draw { get; set; }
}

