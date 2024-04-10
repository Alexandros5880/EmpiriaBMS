using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Services.GooglePlaces.Models;

public class GooglePlaceDetailsResponse
{
    [JsonProperty("candidates")]
    public List<GooglePlaceCandidate> Candidates { get; set; }
}
