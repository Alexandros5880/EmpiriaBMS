using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class ContractDto : EntityDto
{
    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }

    public double ContractualFee { get; set; }

    public DateTime Date { get; set; }

    public byte[]? PMSignature { get; set; }
}
