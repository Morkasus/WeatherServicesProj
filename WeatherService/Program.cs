using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherService.Common;
using System.Threading.Tasks;

namespace WeatherService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Location loction = new Location();
            loction.Name = "London";
            IWeatherDataService weatherDs = null;

            try
            {
                weatherDs = new WeatherDataServiceFactory().GetWeatherDataService(WeatherDataServiceFactory.WeatherServices.OPEN_WEATHER_MAP);
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine("WeatherDataServiceException : {0}", e);
            }

            WeatherData wd = weatherDs.GetWeatherData(loction);
            wd.PrintWeatherData();
            return;
        }
    }
}
