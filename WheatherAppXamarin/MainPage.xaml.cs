using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheatherAppXamarin.Services;
using WheatherAppXamarin.ViewModels;
using Xamarin.Forms;

namespace WheatherAppXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage 
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(new WeatherApiClient());
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel)?.InitData();
        }
    }
}
