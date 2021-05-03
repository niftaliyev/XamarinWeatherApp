using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListXamarin.Tools;
using WheatherAppXamarin.Models;
using WheatherAppXamarin.Services;
using Xamarin.Forms;

namespace WheatherAppXamarin.ViewModels
{
    class MainPageViewModel : ObservableObject
    {
        private IWeatherApiClient _weatherApiClient;

        public Command AddCityCommand { get; set; }
        public Command UpdateCityCommand { get; set; }
        public MainPageViewModel(IWeatherApiClient WeatherApiClient)
        {
            _weatherApiClient = WeatherApiClient;
            AddCityCommand = new Command(AddCity);
            UpdateCityCommand = new Command(InitData);
            AddData();
            InitData();
        }

        private async void AddCity()
        {
            var result = await Application.Current.MainPage.DisplayPromptAsync("AddCity", "EnterCityName", "Add", "Cancel", "Enter here!!!");

            if (!string.IsNullOrEmpty(result))
            {
                var CityTemp = await _weatherApiClient.GetTryWeatherByCityNameAsync(result);
                if (CityTemp != null)
                {
                    if (CityTemp.Cod == 200)
                    {
                        var SItemp = SelectedIndex;
                        var temp = new ObservableCollection<string>(CityNames);
                        temp.Add(result);
                        CityNames = temp;
                        SelectedIndex = SItemp;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", CityTemp.ErrorMessage, "Ok");
                    }
                }
            }

        }

        private async void AddData()
        {
            var geo = await _weatherApiClient.GetCurrentGeoAsync();
            CityNames = new ObservableCollection<string> { geo.city };
            SelectedIndex = 0;
        }

        public async void InitData()
        {
            if (!string.IsNullOrEmpty(SelectedItem))
            {
                var forecast = (await _weatherApiClient.GetWeatherByCityNameAsync(SelectedItem));
                CityName = forecast.Name;
                Temperature = forecast.Main.Temperature;
                ImageSource = forecast.Weather[0].IconGet;
                Humidity = forecast.Main.Humidity;
                Pressure = forecast.Main.Pressure;
                Speed = forecast.Wind.Speed;
                TimeDetailForecasts = new ObservableCollection<DetailsWeatherList>(
                    (await _weatherApiClient.GetWeatherTimeDeteilsByCityIdAsync(forecast.Id)).list.Take(4));
            }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        private string _CityName;
        public string CityName
        {
            get => _CityName;
            set => Set(ref _CityName, value);
        }

        private float _temperature;
        public float Temperature
        {
            get => _temperature;
            set => Set(ref _temperature, value);
        }

        private string _imageSource;
        public string ImageSource
        {
            get => _imageSource;
            set => Set(ref _imageSource, value);
        }

        private float _humidity;
        public float Humidity
        {
            get => _humidity;
            set => Set(ref _humidity, value);
        }

        private float _pressure;
        public float Pressure
        {
            get => _pressure;
            set => Set(ref _pressure, value);
        }

        private float _speed;
        public float Speed
        {
            get => _speed;
            set => Set(ref _speed, value);
        }

        private ObservableCollection<DetailsWeatherList> _timeDetailForecasts = new ObservableCollection<DetailsWeatherList>();
        public ObservableCollection<DetailsWeatherList> TimeDetailForecasts
        {
            get => _timeDetailForecasts;
            set => Set(ref _timeDetailForecasts, value);
        }

        private ObservableCollection<string> _cityNames = new ObservableCollection<string>();
        public ObservableCollection<string> CityNames
        {
            get => _cityNames;
            set => Set(ref _cityNames, value);
        }
    }
}
