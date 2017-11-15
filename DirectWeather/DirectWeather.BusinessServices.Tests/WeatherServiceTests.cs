namespace DirectWeather.BusinessServices.Tests
{
    using System;
    using DirectWeather.DTO;
    using NSubstitute;
    using Xunit;

    public class WeatherServiceTests
    {
        [Fact]
        public void GetWeatherThrowsArgumentNullExceptionForNonExistingCountry()
        {
            var weatherService = new WeatherService();
            Assert.Throws<ArgumentNullException>(() => weatherService.GetWeather("Polanka", "Polankowo"));
        }

        [Fact]
        public void GetWeatherReturnsWeatherObject()
        {
            var weatherService = new WeatherService();
            var weather = weatherService.GetWeather("Poland", "Poznań");
            Assert.Equal(typeof(Weather), weather.GetType());
        }
    }
}
