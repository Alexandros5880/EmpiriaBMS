using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DailyHourDto : EntityDto
{
    public DateTime Date { get; set; }

    public Timespan TimeSpan { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
