
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;
public class Project : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public int StageId { get; set; }
    public ProjectStage? Stage { get; set; }

    public bool Active { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? DeadLine { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }

    public int? OfferId { get; set; }
    public Offer? Offer { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<Discipline>? Disciplines { get; set; }

    public ICollection<Issue>? Complains { get; set; }

    public ICollection<ProjectSubConstructor>? ProjectsSubConstructors { get; set; }
}
