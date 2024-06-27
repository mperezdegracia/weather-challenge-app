namespace Core.Entities;

public class CityWeather
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } =  string.Empty;

    public float Temperature { get; set; }
    public float FeelsLike { get; set; }

}
