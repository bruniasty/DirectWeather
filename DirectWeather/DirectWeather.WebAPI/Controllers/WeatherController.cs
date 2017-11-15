namespace DirectWeather.WebAPI.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using DirectWeather.BusinessServices;

    public class WeatherController : ApiController
    {
        private readonly IWeatherService weatherService;

        public WeatherController()
        {
        }

        public WeatherController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        [Route("api/weather/{country}/{city}")]
        public HttpResponseMessage Get(string country, string city)
        {
            try
            {
                var weather = this.weatherService.GetWeather(country, city);
                return this.Request.CreateResponse(weather);
            }
            catch (Exception e)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
