using EmpiriaBMS.Models.Models;
using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class ProjectDto : EntityDto
{
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

    public DateTime? StartDate { get; set; }

    public DateTime? DeadLine { get; set; }

    public float EstimatedCompleted { get; set; }

    public float DeclaredCompleted { get; set; }

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
