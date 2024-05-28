using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class LedDto : EntityDto
{
    public string Name { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int? OfferId { get; set; }
    public Offer? Offer { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public double PotencialFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? ExpectedDurationDate { get; set; }

    public LedResult Result { get; set; }
}
