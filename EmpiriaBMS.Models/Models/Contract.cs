using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Contract : Entity
{
    [Required]
    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }

    [Required]
    public double ContractualFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public byte[]? PMSignature { get; set; }
}
