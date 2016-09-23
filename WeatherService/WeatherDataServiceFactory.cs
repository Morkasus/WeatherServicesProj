using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Services;

namespace WeatherService
{

    /// <summary>
    ///     WeatherDataServiceFactory
    /// </summary>
    public class WeatherDataServiceFactory
    {
        public enum WeatherServices { OPEN_WEATHER_MAP };

        /// <summary>
        ///     Factory method, return the requested WeatherDataService object thats implements IWeatherDataService. 
        /// </summary>
        /// <param name="ws">WeatherServices - optional service</param>
        /// <returns>IWeatherDataService</returns>
        public IWeatherDataService GetWeatherDataService(WeatherServices ws)
        {
            IWeatherDataService weatherDataService;
            switch (ws)
            {
                case WeatherServices.OPEN_WEATHER_MAP:
                    weatherDataService = OpenWeatherMapService.Instance;
                    break;
                default:
                    throw new WeatherDataServiceException("No Service Found");
            }
            return weatherDataService;
        }
    }
}
