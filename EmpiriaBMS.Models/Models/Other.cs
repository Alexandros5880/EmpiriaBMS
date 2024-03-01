using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Other : Entity
{
    [Required]
    public int TypeId { get; set; }
    public OtherType Type { get; set; }

    [Required]
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public float CompletionEstimation { get; set; }

    public ICollection<ManHour> MenHours { get; set; }

    public ICollection<OtherEmployee> OthersEmployees { get; set; }
}
