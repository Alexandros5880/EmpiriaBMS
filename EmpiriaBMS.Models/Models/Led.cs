using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Models.Enum;

namespace EmpiriaBMS.Models.Models;

public class Led : Entity
{
    public string Country { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public double PotencialFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? ExpectedDurationDate { get; set; }

    public LedResult Result { get; set; }

    public ICollection<Project> Projects { get; set; }
}
