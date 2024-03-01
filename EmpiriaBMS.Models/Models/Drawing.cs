using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Drawing : Entity
{
    [Required]
    public int TypeId { get; set; }
    public DrawingType Type { get; set; }

    [Required]
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; }

    public float CompletionEstimation { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? CompletionDate { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<DrawingEmployee> DrawingsEmployees { get; set; }
}