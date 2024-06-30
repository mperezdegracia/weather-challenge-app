namespace Core;

public class WeatherNotFound : Exception
{
    public WeatherNotFound(string message) : base(message)
    {
    }

    public WeatherNotFound(): base("Weather not found") 
    {
    }

}
