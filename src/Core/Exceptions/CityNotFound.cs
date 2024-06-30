namespace Core.Exceptions;

public class CityNotFound : Exception
{

    public CityNotFound(string message) : base(message)
    {
    }

    public CityNotFound(): base("City not found") 
    {
    }

}
