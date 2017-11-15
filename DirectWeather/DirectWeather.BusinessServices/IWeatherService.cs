namespace DirectWeather.BusinessServices
{
    using DirectWeather.DTO.Interfaces;

    public interface IWeatherService
    {
        IWeather GetWeather(string country, string city);
    }
}