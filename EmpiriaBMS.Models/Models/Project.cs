using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiriaMS.Models.Models.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaMS.Models.Models;
public class Project : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public int? CategoryId { get; set; }
    public ProjectSubCategory Category { get; set; }

    public int StageId { get; set; }
    public ProjectStage Stage { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public bool Active { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? DeadLine { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }

    public int? CalculationDaly { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

    public ICollection<Offer> Offers { get; set; }

    public ICollection<Invoice> Invoices { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<Issue> Complains { get; set; }

    public ICollection<ProjectSubConstructor> ProjectsSubConstructors { get; set; }
}
