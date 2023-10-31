using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstMobileApp
{
    public partial class MainPage : ContentPage
    {
        const string API = "f7744270d84458cd00dea5d6a71875f0";
        public MainPage()
        {
            InitializeComponent();
        }


        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if (city.Length < 2)
            {
                await DisplayAlert("Ошибка", "Название города, слишком короткое", "Исправить");
                return;
            }

            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";

            string responce = await client.GetStringAsync(url);

            var json = JObject.Parse(responce);
            string temp = json["main"]["temp"].ToString();
            resultLabel.Text = $"Погода сейчас: {temp}";
        }
    }
}
