namespace DirectWeather.DTO.Interfaces
{
    public interface ITemperature
    {
        string Format { get; }

        int Value { get; set; }
    }
}