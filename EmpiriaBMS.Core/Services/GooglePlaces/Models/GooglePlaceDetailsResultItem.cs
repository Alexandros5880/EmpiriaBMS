using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services.GooglePlaces.Models;

public class GooglePlaceDetailsResultItem
{
    [JsonProperty("formatted_address")]
    public string FormattedAddress { get; set; }
}
