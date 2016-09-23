using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     Temperature class, contains optional parameters. 
    /// </summary>
    public class Temperature
    {
        public double Value { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Unit { get; set; }
    }
}
