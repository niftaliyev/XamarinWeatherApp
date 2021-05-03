using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WheatherAppXamarin.Models
{

    public class CurrentGeoInfo
    {
        public string organization_name { get; set; }
        public string region { get; set; }
        public int accuracy { get; set; }
        public int asn { get; set; }
        public string organization { get; set; }
        public string timezone { get; set; }
        public string longitude { get; set; }
        public string country_code3 { get; set; }
        public string area_code { get; set; }
        public string ip { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string continent_code { get; set; }
        public string country_code { get; set; }
        public string latitude { get; set; }
    }


    public class TryForecast
    {
        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }

    public class Forecast
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public int Date { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("timezone")]
        public int Timezone { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }
    public class Coord
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
    public class Main
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public float TemperatureMax { get; set; }

        [JsonProperty("pressure")]
        public float Pressure { get; set; }

        [JsonProperty("humidity")]
        public float Humidity { get; set; }
    }
    public class Wind
    {
        [JsonProperty("speed")]
        public float Speed { get; set; }

        [JsonProperty("deg")]
        public int Degree { get; set; }

        [JsonProperty("gust")]
        public float Gust { get; set; }
    }
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
    public class Sys
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
        public string IconGet
        {
            get { return $"http://openweathermap.org/img/wn/{Icon}@2x.png"; ; }
        }
    }

    public class TimeDetailForecast
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public DetailsWeatherList[] list { get; set; } //time weather
        public City city { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class DetailsWeatherList
    {
        public int dt { get; set; }
        public Main main { get; set; } //temp
        public Weather[] weather { get; set; } //icon
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public DateTime dt_txt { get; set; }
        public Rain rain { get; set; }

        public string time
        {
            get { return dt_txt.ToShortTimeString(); }
        }
    }

    public class Rain
    {
        public float _3h { get; set; }
    }
}
