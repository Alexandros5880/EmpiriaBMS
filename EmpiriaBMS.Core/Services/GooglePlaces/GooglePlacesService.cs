using EmpiriaBMS.Core.Services.GooglePlaces.Models;
using EmpiriaBMS.Models.Models;
using Newtonsoft.Json;

namespace EmpiriaBMS.Core.Services.GooglePlaces;

public class GooglePlacesService
{
    private readonly HttpClient _httpClient;
    private string _apiKey = "AIzaSyDMZgJASnCbYBKTiauVNYvP_hf4VNJu6p4";
    protected readonly Logging.LoggerManager _logger;

    public GooglePlacesService(
        HttpClient httpClient,
        Logging.LoggerManager logger
    )
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Address> GetPlaceDetailsByAddressAsync(string address)
    {
        try
        {
            string url = $"https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input={Uri.EscapeDataString(address)}&inputtype=textquery&fields=place_id,formatted_address,geometry&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GooglePlaceDetailsResponse>(content);

                if (result.Candidates != null && result.Candidates.Count > 0)
                {
                    var candidate = result.Candidates[0];
                    var addressComponents = candidate.FormattedAddress.Split(", ");
                    var cityPostal = addressComponents[1].Split(" ");
                    string street = addressComponents[0];
                    string city = cityPostal[0];
                    string postalCode = cityPostal[1];
                    string country = addressComponents[2];
                    string state = "";//statePostalComponents[0];


                    return new Address
                    {
                        FormattedAddress = candidate.FormattedAddress,
                        Street = street,
                        City = city,
                        State = state,
                        PostalCode = postalCode,
                        Country = country,
                        PlaceId = candidate.PlaceId,
                        Latitude = candidate.Geometry.Location.Latitude,
                        Longitude = candidate.Geometry.Location.Longitude
                    };
                }
            }

            return default(Address)!;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception GooglePlacesService.GetPlaceDetailsByAddressAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return default(Address)!;
        }
    }

    public async Task<Address> GetPlaceDetailsByPlaceIdAsync(string placeId)
    {
        try
        {
            string url = $"https://maps.googleapis.com/maps/api/place/details/json?place_id={Uri.EscapeDataString(placeId)}&fields=formatted_address&key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GooglePlaceDetailsResult>(content);

                var addressComponents = result.FormattedAddress.Split(", ");
                string street = addressComponents[0];
                string city = addressComponents[1];
                string statePostal = addressComponents[2];
                string[] statePostalComponents = statePostal.Split(" ");
                string state = statePostalComponents[0];
                string postalCode = statePostalComponents[1];
                string country = addressComponents[3];

                return new Address
                {
                    FormattedAddress = result.FormattedAddress,
                    Street = street,
                    City = city,
                    State = state,
                    PostalCode = postalCode,
                    Country = country,
                    PlaceId = placeId,
                    Latitude = result.Geometry.Location.Latitude,
                    Longitude = result.Geometry.Location.Longitude
                };
            }

            return default(Address)!;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception GooglePlacesService.GetPlaceDetailsByPlaceIdAsync(): {ex.Message}, \n Inner Exception: {ex.InnerException}");
            return default(Address)!;
        }
    }
}
