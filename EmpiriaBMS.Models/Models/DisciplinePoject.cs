using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DisciplinePoject : Entity
{
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}