using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmpiriaBMS.Core.Services.GooglePlaces.Models;

public class GooglePlaceCandidate
{
    [JsonProperty("place_id")]
    public string PlaceId { get; set; }

    [JsonProperty("formatted_address")]
    public string FormattedAddress { get; set; }

    [JsonProperty("geometry")]
    public GooglePlaceGeometry Geometry { get; set; }
}
