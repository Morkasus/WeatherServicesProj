using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using WeatherService.Utils;
using WeatherService.Common;
namespace WeatherService.Services
{
    /// <summary>
    /// OpenWeatherMapService implements IWeatherDataService
    /// </summary>
    public class OpenWeatherMapService : IWeatherDataService
    {
        private enum QueryType {ID, City};
        private static OpenWeatherMapService instance;
        private OpenWeatherMapService(){}

        public static OpenWeatherMapService Instance
        {
            get
            {
                if (instance == null)
                    instance = new OpenWeatherMapService();
                return instance;
            }
        }


        /// <summary>
        ///     Genarate the path to the requested web service.
        /// </summary>
        /// <param name="location">string - requested location</param>
        /// <param name="queryType">enum QueryType - by ID or City</param>
        /// <returns>string , path to the web service</returns>
        private string GenarateQueryString(string location, QueryType queryType)
        {
            StringBuilder urlResult = new StringBuilder(Consts.OPEN_WM_URL);
            urlResult.AppendFormat("&APPID={0}",Consts.OPEN_WM_API_KEY);
            Func<QueryType, string> typeSelector = (q) =>
            {
                switch (queryType)
                {
                    case QueryType.ID:
                        return "&id={0}";
                    case QueryType.City:
                        return "&q={0}";
                    default:
                        return "&q={0}";
                }
            };
            urlResult.AppendFormat(typeSelector(queryType), location);
            return urlResult.ToString();
        }


        /// <summary>
        ///     Implements of IWeatherDataService function.
        ///     Ganarate the service url
        ///     Download the xml file
        ///     prasing the xml to WeatherData object.
        /// </summary>
        /// <param name="location">Location - requested location</param>
        /// <returns>WeatherData object</returns>
        public WeatherData GetWeatherData(Location location) 
        {
            string url = GenarateQueryString(location.Name, QueryType.City);
            string weatherXml = DownloadWeatherXml(url);
            try
            {
                return FillWeatherData(weatherXml);
            }
            catch(WeatherDataServiceException e)
            {
                Console.WriteLine("WeatherDataServiceException : {0}", e);
                return null;
            }
        }

        /// <summary>
        ///     Add to WeatherData object the content from the xml file with Linq.
        /// </summary>
        /// <param name="weatherXml">string - weather xml as string</param>
        /// <returns>WeatherData object</returns>
        private WeatherData FillWeatherData(string weatherXml) 
        {
            WeatherData wd = new WeatherData();
            XDocument ob = XDocument.Parse(weatherXml);
            try {
                wd = (from x in ob.Descendants("current")
                      select new WeatherData
                      {
                          City = (from city in x.Descendants("city")
                                  select new City
                                  {
                                      ID = city.Attribute("id")?.Value ?? "",
                                      Name = city.Attribute("name")?.Value ?? "",
                                      Lon = Convert.ToDouble(city.Element("coord")?.Attribute("lon")?.Value ?? "-1"),
                                      Lat = Convert.ToDouble(city.Element("coord")?.Attribute("lat")?.Value ?? "-1"),
                                      Country = city.Element("country")?.Value ?? "",
                                      SunSet = Convert.ToDateTime(city.Element("sun")?.Attribute("set")?.Value ?? "-1"),
                                      SunRise = Convert.ToDateTime(city.Element("sun")?.Attribute("rise")?.Value ?? "-1")
                                  }).ToArray()[0],

                          Temperature = (from temperature in x.Descendants("temperature")
                                         select new Temperature
                                         {
                                             Value = Convert.ToDouble(temperature.Attribute("value")?.Value ?? "-1"),
                                             Min = Convert.ToDouble(temperature.Attribute("min")?.Value ?? "-1"),
                                             Max = Convert.ToDouble(temperature.Attribute("max")?.Value ?? "-1"),
                                             Unit = temperature.Attribute("unit")?.Value ?? ""
                                         }).ToArray()[0],

                          Humidity = (from humidity in x.Descendants("humidity")
                                      select new Humidity
                                      {
                                          Value = Convert.ToDouble(humidity.Attribute("value")?.Value ?? "-1"),
                                          Unit = humidity.Attribute("unit")?.Value ?? ""
                                      }).ToArray()[0],

                          Pressure = (from pressure in x.Descendants("pressure")
                                      select new Pressure
                                      {
                                          Value = Convert.ToDouble(pressure.Attribute("value")?.Value ?? "-1"),
                                          Unit = pressure.Attribute("unit")?.Value ?? ""
                                      }).ToArray()[0],

                          Wind = (from wind in x.Descendants("wind")
                                  select new Wind
                                  {                      
                                      Speed = Convert.ToDouble(wind.Element("speed")?.Attribute("value")?.Value ?? "-1"),
                                      Gusts = Convert.ToDouble(wind.Element("gusts")?.Attribute("value")?.Value ?? "-1"),
                                      DirectionValue = Convert.ToDouble(wind.Element("direction")?.Attribute("value")?.Value ?? "-1"),
                                      DirectionName = wind.Element("direction")?.Attribute("name")?.Value ?? "",
                                      DirectionCode = wind.Element("direction")?.Attribute("code")?.Value ?? ""
                                  }).ToArray()[0],

                          Clouds = (from clouds in x.Descendants("clouds")
                                    select new Clouds
                                    {
                                        Value = Convert.ToDouble(clouds.Attribute("value")?.Value ?? "-1"),
                                        Name = clouds.Attribute("name")?.Value ?? ""
                                    }).ToArray()[0],

                          Precipitation = x.Element("precipitation")?.Attribute("mode")?.Value ?? "",

                          Weather = (from w in x.Descendants("weather")
                                     select new Weather
                                     {
                                         Number = Convert.ToDouble(w.Attribute("number")?.Value ?? "-1"),
                                         Value = w.Attribute("value")?.Value ?? "",
                                         Icon = w.Attribute("icon")?.Value ?? ""
                                     }).ToArray()[0],

                          LastUpdate = Convert.ToDateTime(x.Element("lastupdate")?.Attribute("value")?.Value ?? "")

                      }).ToArray()[0];
            }
            catch(Exception e2)
            {
                throw new WeatherDataServiceException(e2.Message);
            }

            return wd;
        }

        /// <summary>
        ///     Send the request message and get the xml file with the weather data.
        /// </summary>
        /// <param name="url">string - service url</param>
        /// <returns>Xml file as string</returns>
        private string DownloadWeatherXml(string url)
        {
            string weatherXml = String.Empty;
            WebClient client = new WebClient();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                weatherXml = reader.ReadToEnd();
            }
            return weatherXml;
        }
    }
}
