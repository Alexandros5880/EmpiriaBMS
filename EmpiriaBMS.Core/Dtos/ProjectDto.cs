using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectDto : EntityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public long EstimatedMandays { get; set; }

    public long EstimatedHours { get; set; }

    public int StageId { get; set; }
    public ProjectStage Stage { get; set; }

    public bool Active { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DeadLine { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }

    public int? ProjectManagerId { get; set; }
    public User? ProjectManager { get; set; }

    public int? OfferId { get; set; }
    public Offer? Offer { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public ICollection<Invoice> Invoices { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<Issue> Complains { get; set; }

    public ICollection<ProjectSubConstructor> ProjectsSubConstructors { get; set; }
}
