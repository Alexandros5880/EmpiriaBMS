using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services.GooglePlaces.Models;

public class GooglePlaceGeometry
{
    [JsonProperty("location")]
    public GooglePlaceLocation Location { get; set; }
}
