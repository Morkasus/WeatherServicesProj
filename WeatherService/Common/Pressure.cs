using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     Pressure class, contains optional parameters. 
    /// </summary>
    public class Pressure
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }
}
