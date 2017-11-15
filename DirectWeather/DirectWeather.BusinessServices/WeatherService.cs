namespace DirectWeather.BusinessServices
{
    using System;
    using System.Net;
    using DirectWeather.DTO;
    using DirectWeather.DTO.Interfaces;
    using Newtonsoft.Json.Linq;

    public class WeatherService : IWeatherService
    {
        private const string ApiFormat = @"http://api.openweathermap.org/data/2.5/weather?q={0},{1}&units=metric&APPID=055680559e08f48e2b4a958d9d40c0e5";

        public IWeather GetWeather(string country, string city)
        {
            var countryCode = this.GetCountryIso(country);
            var responseJson = this.GetJsonFromApi(string.Format(ApiFormat, city, countryCode));
            var rss = JObject.Parse(responseJson);

            return new Weather
            {
                Location = new Location
                {
                    City = city,
                    Country = country
                },

                Temperature = new Temperature
                {
                  Value = (int)rss["main"]["temp"]
                },

                Humidity = (int)rss["main"]["humidity"]
            };
        }

        private string GetCountryIso(string country)
        {
            if (CountryISO3166Codes.IsoDictionary.ContainsKey(country.ToUpper()))
            {
                return CountryISO3166Codes.IsoDictionary[country.ToUpper()];
            }

            throw new ArgumentNullException();
        }

        private string GetJsonFromApi(string apiFormat)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(apiFormat);
            }
        }
    }
}
