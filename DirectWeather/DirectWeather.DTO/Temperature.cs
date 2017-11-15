namespace DirectWeather.DTO
{
    using DirectWeather.DTO.Interfaces;

    public class Temperature : ITemperature
    {
        public string Format => "Celsius";

        public int Value { get; set; }
    }
}