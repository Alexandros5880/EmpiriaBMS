using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;
public class UserRole : Entity
{
    [Required]
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User User { get; set; }

    [Required]
    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }
}