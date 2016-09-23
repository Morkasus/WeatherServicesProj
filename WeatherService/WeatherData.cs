using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Common;

namespace WeatherService
{

    /// <summary>
    ///     WeatherData class, contains all optional parameters.
    /// </summary>
    public class WeatherData
    {

        public City City { get; set; }
        public Temperature Temperature { get; set; }
        public Humidity Humidity { get; set; }
        public Pressure Pressure { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Precipitation { get; set; }
        public Weather Weather { get; set; }
        public DateTime LastUpdate { get; set; }


        /// <summary>
        ///     Print to screen the weather data.
        /// </summary>
        public void PrintWeatherData()
        {
            Console.WriteLine("------ City -------");
            Console.WriteLine(" 1. ID: {0}\n 2. Country: {1}\n 2. Name: {2}\n 3. Lon: {3}\n 4. Lat: {4}\n 3. Sunrise: {5}\n 4. Sunset: {6}\n", 
                City.ID, City.Country, City.Name, City.Lon, City.lat, City.SunRise, City.SunSet);

            Console.WriteLine("\n------ Temperature -------");
            Console.WriteLine(" 1. Value: {0}\n 2. Max: {1}\n 2. Min: {2}\n 3. Unit: {3}\n",
                Temperature.Value, Temperature.Max, Temperature.Min, Temperature.Unit);

            Console.WriteLine("\n------ Humidity -------");
            Console.WriteLine(" 1. Value: {0}\n 2. Unit: {1}\n",
                Humidity.Value, Humidity.Unit);

            Console.WriteLine("\n------ Pressure -------");
            Console.WriteLine(" 1. Value: {0}\n 2. Unit: {1}\n",
                Pressure.Value, Pressure.Unit);

            Console.WriteLine("\n------ Wind -------");
            Console.WriteLine(" 1. Speed: {0}\n 2. Gusts: {1}\n 2. DirectionValue: {2}\n 3. DirectionCode: {3}\n 4. DirectionName: {4}\n",
                Wind.Speed, Wind.Gusts, Wind.DirectionValue, Wind.DirectionCode, Wind.DirectionName);

            Console.WriteLine("\n------ Clouds -------");
            Console.WriteLine(" 1. Value: {0}\n 2. Name: {1}\n",
                Clouds.Value, Clouds.Name);

            Console.WriteLine("\n------ Precipitation -------");
            Console.WriteLine(" 1. Precipitation: {0}\n",
                Precipitation);

            Console.WriteLine("\n------ Weather -------");
            Console.WriteLine(" 1. Number: {0}\n 2. Value: {1}\n 2. Icon: {2}\n",
                Weather.Number, Weather.Value, Weather.Icon);

            Console.WriteLine("\n------ LastUpdate -------");
            Console.WriteLine(" 1. LastUpdate: {0}\n",
                LastUpdate);
        }
    }
 
}
