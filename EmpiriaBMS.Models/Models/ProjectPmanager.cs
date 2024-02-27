using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectPmanager : Entity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int ProjectManagerId { get; set; }
    public User ProjectManager { get; set; }
}
