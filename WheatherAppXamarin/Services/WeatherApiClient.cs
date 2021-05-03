using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WheatherAppXamarin.Models;
using Xamarin.Forms;
using XamarinTranslator;

namespace WheatherAppXamarin.Services
{
    class WeatherApiClient : IWeatherApiClient
    {
        private readonly string _apiKey = "736d5ca18169a3d05c53bc9daa91d0af";
        private readonly string _apiUnit = "metric";
        private readonly string _apiUrl = "https://api.openweathermap.org/data/2.5";

        private readonly string _apiWeather = "weather";
        private readonly string _apiForecast = "forecast";


        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<Forecast> GetWeatherByCityNameAsync(string CityName)
        {
            try
            {
                var uri = new Uri($"{_apiUrl}/{_apiWeather}")
                .AddQueryParameter("q", CityName)
                .AddQueryParameter("apikey", _apiKey)
                .AddQueryParameter("units", _apiUnit);

                var json = await _httpClient.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<Forecast>(json);

                return result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "Ok");
            }

            return null;
        }

        public async Task<TryForecast> GetTryWeatherByCityNameAsync(string CityName)
        {
            try
            {
                var uri = new Uri($"{_apiUrl}/{_apiWeather}")
                        .AddQueryParameter("q", CityName)
                        .AddQueryParameter("apikey", _apiKey)
                        .AddQueryParameter("units", _apiUnit);

                var json = await _httpClient.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<TryForecast>(json);

                return result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "Ok");
            }

            return null;
        }

        public async Task<Forecast> GetWeatherByGeoCordinate(double Latitude, double Longitude)
        {
            try
            {
                var uri = new Uri($"{_apiUrl}/{_apiWeather}")
                            .AddQueryParameter("lat", Latitude.ToString())
                            .AddQueryParameter("lon", Longitude.ToString())
                            .AddQueryParameter("apikey", _apiKey)
                            .AddQueryParameter("units", _apiUnit);

                var json = await _httpClient.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<Forecast>(json);

                return result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "Ok");
            }

            return null;
        }

        public async Task<TimeDetailForecast> GetWeatherTimeDeteilsByCityIdAsync(int CityId)
        {
            try
            {
                var uri = new Uri($"{_apiUrl}/{_apiForecast}")
                        .AddQueryParameter("id", CityId.ToString())
                        .AddQueryParameter("apikey", _apiKey)
                        .AddQueryParameter("units", _apiUnit);

                var json = await _httpClient.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<TimeDetailForecast>(json);

                return result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "Ok");
            }

            return null;
        }

        public async Task<CurrentGeoInfo> GetCurrentGeoAsync()
        {
            try
            {
                var json = await _httpClient.GetStringAsync("https://get.geojs.io/v1/ip/geo.json");
                var result = JsonConvert.DeserializeObject<CurrentGeoInfo>(json);

                return result;
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "Ok");
            }

            return null;
        }
    }
}
