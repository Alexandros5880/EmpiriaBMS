using EmpiriaBMS.Models.Enum;
using EmpiriaBMS.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Core.Dtos;

public class ClientDto : UserDto
{
    [Required]
    public string CompanyName { get; set; }

    public string Name { get; set; }

    public int? AddressId { get; set; }
    public Address? Address { get; set; }

    public double PotencialFee { get; set; }

    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime? ExpectedDurationDate { get; set; }

    public ClientResult Result { get; set; }

    public ICollection<DailyTime>? DailyTime { get; set; }

    public ICollection<Offer>? Offers { get; set; }

    [NotMapped]
    public new string FullName => $"{LastName} {MidName} {FirstName}";
}
