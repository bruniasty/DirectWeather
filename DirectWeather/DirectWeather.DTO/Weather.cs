namespace DirectWeather.DTO
{
    using DirectWeather.DTO.Interfaces;

    public class Weather : IWeather
    {
        public ILocation Location { get; set; }

        public ITemperature Temperature { get; set; }

        public int Humidity { get; set; }
    }
}