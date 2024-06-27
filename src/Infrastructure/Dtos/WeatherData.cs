using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Infrastructure.Dtos;
public class WeatherData
{
    [JsonPropertyName("coord")]
    public CoordDto Coord { get; set; } = new CoordDto();

    [JsonPropertyName("weather")]
    public List<WeatherDto> Weather { get; set; } = new List<WeatherDto>();

    [JsonPropertyName("base")]
    public string Base { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public MainDto Main { get; set; } = new MainDto();

    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }

    [JsonPropertyName("wind")]
    public WindDto Wind { get; set; } = new WindDto();

    [JsonPropertyName("clouds")]
    public CloudsDto Clouds { get; set; } = new CloudsDto();

    [JsonPropertyName("dt")]
    public long Dt { get; set; }

    [JsonPropertyName("sys")]
    public SysDto Sys { get; set; } = new SysDto();

    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("cod")]
    public int Cod { get; set; }
}

public class CoordDto
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }
}

public class WeatherDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("main")]
    public string Main { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("icon")]
    public string Icon { get; set; } = string.Empty;
}

public class MainDto
{
    [JsonPropertyName("temp")]
    public float Temp { get; set; }

    [JsonPropertyName("feels_like")]
    public float FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public float TempMin { get; set; }

    [JsonPropertyName("temp_max")]
    public float TempMax { get; set; }

    [JsonPropertyName("pressure")]
    public int Pressure { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("sea_level")]
    public int SeaLevel { get; set; }

    [JsonPropertyName("grnd_level")]
    public int GrndLevel { get; set; }
}

public class WindDto
{
    [JsonPropertyName("speed")]
    public float Speed { get; set; }

    [JsonPropertyName("deg")]
    public int Deg { get; set; }

    [JsonPropertyName("gust")]
    public float Gust { get; set; }
}

public class CloudsDto
{
    [JsonPropertyName("all")]
    public int All { get; set; }
}

public class SysDto
{
    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("sunrise")]
    public long Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public long Sunset { get; set; }
}