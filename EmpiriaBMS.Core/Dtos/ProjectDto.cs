using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public double? Fee { get; set; }

    public int TypeId { get; set; }
    public ProjectType Type { get; set; }

    public bool Active { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DeadLine { get; set; }

    public float EstimatedCompleted { get; set; }

    public float Completed { get; set; }

    public float WorkPackegedCompleted { get; set; }

    public int? CalculationDaly { get; set; }

    public int? CustomerId { get; set; }
    public User? Customer { get; set; }

    public int? InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public int? PaymentId { get; set; }
    public Payment? Payment { get; set; }

    public int? SubContractorId { get; set; }
    public User? SubContractor { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }
}
