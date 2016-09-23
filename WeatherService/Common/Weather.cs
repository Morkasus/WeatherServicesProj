using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     Weather class, contains optional parameters. 
    /// </summary>
    public class Weather
    {
        public double Number { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
    }
}
