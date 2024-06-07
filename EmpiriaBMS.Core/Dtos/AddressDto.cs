using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;

namespace EmpiriaBMS.Core.Dtos;

public class AddressDto : EntityDto
{
    public string FormattedAddress { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string PlaceId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public List<Project> Projects { get; set; }
}
