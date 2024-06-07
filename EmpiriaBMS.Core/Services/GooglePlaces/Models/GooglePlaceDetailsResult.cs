using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services.GooglePlaces.Models;

public class GooglePlaceDetailsResult
{
    [JsonProperty("result")]
    public GooglePlaceDetailsResultItem Result { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("geometry")]
    public GooglePlaceGeometry Geometry { get; set; }

    public string FormattedAddress => Result?.FormattedAddress;
}
