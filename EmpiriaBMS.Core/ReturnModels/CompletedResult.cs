using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.ReturnModels;

public class CompletedResult
{
    public int ProjectCompleted { get; set; }
    public int DisciplineCompleted { get; set; }
    public int DrawCompleted { get; set; }
    public int OtherCompleted { get; set; }
}
