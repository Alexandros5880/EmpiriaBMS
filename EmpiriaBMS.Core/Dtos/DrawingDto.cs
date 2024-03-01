using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DrawingDto : EntityDto
{
    public int TypeId { get; set; }
    public DrawingType Type { get; set; }

    public float CompletionEstimation { get; set; }

    public DateTime? CompletionDate { get; set; }

    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
}
