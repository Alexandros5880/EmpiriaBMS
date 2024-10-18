using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Core.Dtos;

public class UserDto : EntityDto
{
    // MicrosoftTeams Email
    public string? ProxyAddress { get; set; }

    public string? PasswordHash { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    public string? FirstName { get; set; }

    public string? MidName { get; set; }

    public string? TeamsObjectId { get; set; }

    [Required]
    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Phone3 { get; set; }

    public string? Description { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? SubConstructorId { get; set; }
    public SubConstructor? SubConstructor { get; set; }

    public ICollection<Email>? Emails { get; set; }

    public ICollection<Project>? PMProjects { get; set; }

    public ICollection<Discipline>? Disciplines { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }

    public ICollection<DeliverableEmployee>? DeliverablesEmployees { get; set; }

    public ICollection<SupportiveWorkEmployee>? SupportiveWorksEmployees { get; set; }

    public ICollection<DisciplineEngineer>? DisciplinesEngineers { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<Issue>? MyIssues { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {MidName} {FirstName}";

    [NotMapped]
    public ICollection<RoleDto>? Roles { get; set; }
}
