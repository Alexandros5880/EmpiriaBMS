using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectSubConstractor : Entity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int SubConstructorId { get; set; }
    public SubConstructor SubConstructor { get; set; }
}
