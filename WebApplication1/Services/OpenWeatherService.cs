using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using WebApplication1.Dto;
using System.Text.Json;
using WebApplication1.Profiles;

namespace WebApplication1.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        private readonly ForecastProfile _forecastProfile;
        private readonly CurrentWeatherProfile _currentWeatherProfile;

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions();

        public OpenWeatherService(HttpClient HttpClient, IConfiguration config, ForecastProfile forecastProfile, CurrentWeatherProfile currentWeatherProfile)
        {
            _config = config;
            _forecastProfile = forecastProfile;
            _currentWeatherProfile = currentWeatherProfile; 

            _httpClient = HttpClient;
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "testtttt");

        }

        public async Task<BasicCurrentWeatherDto> GetCurrentWeather(string City)
        {  
            var uriBuilderParams = new UriBuilder();
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["q"] = City;
            queryParams["appid"] = _config["OpenWeatherApiKey"];
            uriBuilderParams.Query = queryParams.ToString(); 

            var response = await _httpClient.GetAsync("weather" + uriBuilderParams.Query);

            // This will throw System.Net.Http.HttpRequestException if a request is unsuccessful
            response.EnsureSuccessStatusCode(); 

            using (var responseStream = await response.Content.ReadAsStreamAsync()  ){

                var responseCurrentWeather = await JsonSerializer.DeserializeAsync<OpenWeatherCurrentWeatherDto>(responseStream, Options);
                 
                var CurrentWeather = _currentWeatherProfile.Map(responseCurrentWeather);
                await responseStream.FlushAsync();

                return CurrentWeather;
            } 
        }

        public async Task<BasicForecastDto> GetForecast(decimal lat, decimal lon)
        {
            var uriBuilderParams = new UriBuilder();
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["lat"] = lat.ToString();//?!
            queryParams["lon"] = lon.ToString();
            queryParams["exclude"] = "minutely,hourly";
            queryParams["appid"] = _config["OpenWeatherApiKey"];
            uriBuilderParams.Query =  queryParams.ToString();

            var response = await _httpClient.GetAsync("onecall" + uriBuilderParams.Query); 

            response.EnsureSuccessStatusCode();
             
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var responseForecast = await JsonSerializer.DeserializeAsync<OpenWeatherForecastDaily>(responseStream, Options);

                var basicForecast = _forecastProfile.Map(responseForecast);
                await responseStream.FlushAsync();

                return basicForecast; 
            }

        }
    }
}
