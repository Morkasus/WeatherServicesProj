using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{

    /// <summary>
    ///     IWeatherDataService interface provider GetWeatherData function.
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        ///     GetWeatherData function, get the data from the service and parse to WeatherData object.
        /// </summary>
        /// <param name="location">Location - requested location</param>
        /// <returns>WeatherData object</returns>
        WeatherData GetWeatherData(Location location);
    }
}
