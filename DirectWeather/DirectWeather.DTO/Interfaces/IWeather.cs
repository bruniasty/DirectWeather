namespace DirectWeather.DTO.Interfaces
{
    public interface IWeather
    {
        ILocation Location { get; set; }

        ITemperature Temperature { get; set; }

        int Humidity { get; set; }
    }
}