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
    public int TypeId { get; set; }
    public DisciplineType Type { get; set; }

    public long EstimatedHours { get; set; }

    public float Completed { get; set; }
}
