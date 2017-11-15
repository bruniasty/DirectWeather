namespace DirectWeather.WebAPI.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using DirectWeather.BusinessServices;
    using DirectWeather.DTO;
    using DirectWeather.DTO.Interfaces;
    using DirectWeather.WebAPI.Controllers;
    using NSubstitute;
    using Xunit;

    public class WeatherControllerTests
    {
        private const string Country = "poland";

        private const string City = "warsaw";

        [Fact]
        public async void GetMethodReturnsWeatherObject()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeather(Country, City).Returns(new Weather());

            var weatherController = new WeatherController(weatherService) { Request = new HttpRequestMessage() };
            weatherController.Request.SetConfiguration(new HttpConfiguration());

            var response = weatherController.Get(Country, City);
            var weather = await response.Content.ReadAsAsync<IWeather>();
            Assert.Equal(typeof(Weather), weather.GetType());
        }

        [Fact]
        public async void GetMethodForNonExistingCityReturnsNull()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeather(Country, "warsawawaa").Returns(info => null);

            var weatherController = new WeatherController(weatherService) { Request = new HttpRequestMessage() };
            weatherController.Request.SetConfiguration(new HttpConfiguration());

            var response = weatherController.Get(Country, "warsawawaa");
            var weather = await response.Content.ReadAsAsync<IWeather>();
            Assert.Null(weather);
        }

        [Fact]
        public void GetMethodInControllerCallsGetWeatherMethodInService()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeather(Country, City).Returns(info => null);

            var weatherController = new WeatherController(weatherService) { Request = new HttpRequestMessage() };
            weatherController.Request.SetConfiguration(new HttpConfiguration());

            weatherController.Get(Country, City);
            weatherService.Received().GetWeather(Country, City);
        }

        [Fact]
        public void GetWeatherReturnsInternalServerErrorForNonExistingCountry()
        {
            var weatherService = Substitute.For<IWeatherService>();
            weatherService.GetWeather(Country, City).Returns(x => throw new ArgumentNullException());

            var weatherController = new WeatherController(weatherService) { Request = new HttpRequestMessage() };
            weatherController.Request.SetConfiguration(new HttpConfiguration());
            
            Assert.Equal(HttpStatusCode.InternalServerError, weatherController.Get(Country, City).StatusCode);
        }
    }
}
