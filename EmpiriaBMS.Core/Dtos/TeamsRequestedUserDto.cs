using EmpiriaBMS.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class TeamsRequestedUserDto : EntityDto
{
    public string DisplayName { get; set; }
    public string ProxyAddress { get; set; }
    public string ObjectId { get; set; }
}
