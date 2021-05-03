using System.Threading.Tasks;
using WheatherAppXamarin.Models;

namespace WheatherAppXamarin.Services
{
    internal interface IWeatherApiClient
    {
        Task<Forecast> GetWeatherByCityNameAsync(string CityName);
        Task<TryForecast> GetTryWeatherByCityNameAsync(string CityName);
        Task<Forecast> GetWeatherByGeoCordinate(double Latitude, double Longitude);
        Task<TimeDetailForecast> GetWeatherTimeDeteilsByCityIdAsync(int CityId);
        Task<CurrentGeoInfo> GetCurrentGeoAsync();
    }
}