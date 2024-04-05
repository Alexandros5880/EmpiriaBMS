using EmpiriaMS.Models.Models.Base;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectInvoice : Entity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
}

