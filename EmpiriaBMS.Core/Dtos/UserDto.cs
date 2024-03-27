using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public ICollection<Email> Emails { get; set; }

    public ICollection<RoleDto> Roles { get; set; }
}
