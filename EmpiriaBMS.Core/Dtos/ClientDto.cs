using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmpiriaBMS.Core.Dtos.Base;

namespace EmpiriaBMS.Core.Dtos;

public class ClientDto : EntityDto
{
    [Required]
    public string CompanyName { get; set; }

    public string Name { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public long? AddressId { get; set; }
    public Address? Address { get; set; }

    public double PotencialFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? ExpectedDurationDate { get; set; }

    public ClientResult Result { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<Offer>? Offers { get; set; }

    public ICollection<User>? Users { get; set; }

    public ICollection<Email>? Emails { get; set; }
}
