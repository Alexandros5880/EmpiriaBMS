using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class OtherDto : EntityDto
{
    public int TypeId { get; set; }
    public OtherType Type { get; set; }

    public long MenHours { get; set; }

    public float CompletionEstimation { get; set; }

    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
}
