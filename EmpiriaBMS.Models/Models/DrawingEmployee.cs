using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DrawingEmployee : Entity
{
    public int DrawingId { get; set; }
    public Drawing Drawing { get; set; }

    public int EmployeeId { get; set; }
    public User Employee { get; set; }
}
