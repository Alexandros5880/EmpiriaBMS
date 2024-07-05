using EmpiriaBMS.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;

public class Lead : Entity
{
    public string Name { get; set; }

    public int? ClientId { get; set; }
    public Client? Client { get; set; }

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
