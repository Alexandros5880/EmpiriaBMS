using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;
public class User : Entity
{
    // MicrosoftTeams Email
    public string ProxyAddress { get; set; }

    public string? PasswordHash { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string? MidName { get; set; }

    public string? TeamsObjectId { get; set; }

    [Required]
    public string Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Phone3 { get; set; }

    public string? Description { get; set; }

    public ICollection<Email> Emails { get; set; }
    
    public ICollection<Project> PMProjects { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    
    public ICollection<DrawingEmployee> DrawingsEmployees { get; set; }

    public ICollection<OtherEmployee> OthersEmployees { get; set; }

    public ICollection<DisciplineEngineer> DisciplinesEngineers { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<DailyTime> PersonalTime { get; set; }

    public ICollection<DailyTime> TrainingTime { get; set; }

    public ICollection<DailyTime> CorporateEventTime { get; set; }

    public ICollection<Issue> MyIssues { get; set; }

    public ICollection<ProjectSubConstructor> ProjectsSubConstructors { get; set; }
}