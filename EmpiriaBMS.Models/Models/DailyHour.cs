﻿using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class DailyHour : Entity
{
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime Date { get; set; }

    public Timespan TimeSpan { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}