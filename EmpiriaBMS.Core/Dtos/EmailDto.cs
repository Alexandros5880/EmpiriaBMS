using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class EmailDto : EntityDto
{
    public string? Address { get; set; }

    public long? UserId { get; set; }
    public User? User { get; set; }

    public long? ClientId { get; set; }
    public Client? Client { get; set; }

    public long? SubConstructorId { get; set; }
    public SubConstructor? SubConstructor { get; set; }
}
