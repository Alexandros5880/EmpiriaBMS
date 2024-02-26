using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DisciplineDto : EntityDto
{
    public string Name { get; set; }

    public long EstimatedHours { get; set; }

    public float Completed { get; set; }

    public int? EngineerId { get; set; }
    public User? Engineer { get; set; }
}
