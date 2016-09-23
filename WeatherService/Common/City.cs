using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.Common
{
    /// <summary>
    ///     City class, contains optional parameters of the city. 
    /// </summary>
    public class City
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}
