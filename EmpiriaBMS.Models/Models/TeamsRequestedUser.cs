using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class TeamsRequestedUser : Entity
{
    public string DisplayName { get; set; }
    public string ProxyAddress { get; set; }
    public string ObjectId { get; set; }
}
