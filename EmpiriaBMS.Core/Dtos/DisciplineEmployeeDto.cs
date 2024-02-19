using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DisciplineEmployeeDto : EntityDto
{
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
