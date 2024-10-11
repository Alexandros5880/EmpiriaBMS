using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class ProjectSubConstractor : Entity
{
    public long ProjectId { get; set; }
    public Project Project { get; set; }

    public long SubConstructorId { get; set; }
    public SubConstructor SubConstructor { get; set; }
}
