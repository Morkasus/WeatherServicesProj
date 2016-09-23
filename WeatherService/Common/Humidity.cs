using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     Humidity class, contains optional parameters. 
    /// </summary>
    public class Humidity
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
}
