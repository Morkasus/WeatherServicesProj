using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     Wind class, contains optional parameters. 
    /// </summary>
    public class Wind
    {
        public double Speed { get; set; }
        public double Gusts { get; set; }
        public double DirectionValue { get; set; }
        public string DirectionCode { get; set; }
        public string DirectionName { get; set; }
    }
}
