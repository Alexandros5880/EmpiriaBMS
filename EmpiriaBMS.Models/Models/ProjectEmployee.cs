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
public class ProjectEmployee : Entity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
