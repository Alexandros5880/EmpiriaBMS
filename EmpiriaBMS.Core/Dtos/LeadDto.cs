﻿using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Core.Dtos;

public class LeadDto : EntityDto
{
    public string Name { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public double PotencialFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? ExpectedDurationDate { get; set; }

    public LeadResult Result { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<Offer> Offers { get; set; }
}