using EmpiriaBMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Projection : Entity
{
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public double ProjectFee { get; set; }
    
    public double LedFee { get; set; }

    [NotMapped]
    public double RestFee => LedFee - ProjectFee;

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? EstimatedDurationDate { get; set; }
}
