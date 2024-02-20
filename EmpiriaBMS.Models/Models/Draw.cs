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

public class Draw : Entity
{
    [Required]
    public string Name { get; set; }

    public double ManHours { get; set; }

    public int? CompletionEstimation { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? CompletionDate { get; set; }

    public ICollection<DisciplineDraw> DisciplinesDraws { get; set; }
}