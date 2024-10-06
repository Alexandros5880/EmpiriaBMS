using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class SubConstructorDto : EntityDto
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public string Phone { get; set; }

    public ICollection<Email>? Emails { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }

    public ICollection<ProjectSubConstractor>? ProjectsSubConstructors { get; set; }
}
