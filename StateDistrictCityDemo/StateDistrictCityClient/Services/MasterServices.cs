using Microsoft.Extensions.Options;
using StateDistrictCityClient.Models.Entities;

namespace StateDistrictCityClient.Services
{
    public class MasterServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public MasterServices(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _apiUrl = appSettings.Value.BaseUrl + "master";
        }

        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            return await  _httpClient.GetFromJsonAsync<IEnumerable<State>>(_apiUrl);
        }
        public async Task<IEnumerable<District>> GetDistrictsByStateIdAsync(int stateId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<District>>($"{_apiUrl}/{stateId}");
        }
        public async Task<IEnumerable<City>> GetCityByDistrictIdAsync(int districtId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<City>>($"{_apiUrl}/{districtId}");
        }
    }
}
