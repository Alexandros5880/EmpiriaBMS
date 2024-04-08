using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class PaymentType : Entity
{
    [Required]
    public string Name { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
