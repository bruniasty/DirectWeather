namespace DirectWeather.DTO
{
    using DirectWeather.DTO.Interfaces;

    public class Location : ILocation
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
}