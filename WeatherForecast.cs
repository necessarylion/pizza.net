using System.ComponentModel;

namespace pizza;

public class WeatherForecast {
  public DateOnly Date { get; set; }

  [DefaultValue(100)]
  public int TemperatureC { get; set; }

  [DefaultValue(32)]
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

  [DefaultValue("It's a nice day")]
  public string? Summary { get; set; }
}
