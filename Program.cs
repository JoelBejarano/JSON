using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Console;

namespace JSON
{
    namespace SerializeBasic
    {
        public class Program
        {
            public static void Main()
            {
                var weatherForecast = new WeatherForecast
                {
                    Date = DateTime.Parse("2019-08-01"),
                    TemperatureCelsius = 25,
                    Summary = "Hot"
                };

                var PhoenixForecast = new WeatherForecast
                {
                    Date = DateTime.Parse("2019-08-01"),
                    TemperatureCelsius = 28,
                    Summary = "Hot"
                };

                string jsonString = JsonSerializer.Serialize(weatherForecast);
                WriteLine(jsonString);

                string PhoenixString = JsonSerializer.Serialize(PhoenixForecast);
                WriteLine(PhoenixString);

                WeatherForecast w = JsonSerializer.Deserialize<WeatherForecast>(PhoenixString);
                WriteLine(w.Summary);

                ReadKey();
            }


        }

    }
}
