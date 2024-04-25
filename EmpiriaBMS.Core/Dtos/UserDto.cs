using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class UserDto : EntityDto
{
    public string ProxyAddress { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string? MidName { get; set; }

    public string? TeamsObjectId { get; set; }

    public string Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Phone3 { get; set; }

    public string? Description { get; set; }

    public ICollection<Email> Emails { get; set; }

    public ICollection<RoleDto> Roles { get; set; }

    public ICollection<ProjectSubConstructor> ProjectsSubConstructors { get; set; }
}
