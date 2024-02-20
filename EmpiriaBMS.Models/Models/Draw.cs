using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Draw : Entity
{
    [Required]
    public string Name { get; set; }

    public double ManHours { get; set; }

    public int? CompletionEstimation { get; set; }

    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }
}