using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DisciplineEmployee : Entity
{
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
