using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Common;


namespace WeatherService.Services.Tests
{
    [TestClass()]
    public class OpenWeatherMapServiceTests
    {
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            OpenWeatherMapService openWeatherMapService = OpenWeatherMapService.Instance;

            WeatherData exeptedWeatherData = new WeatherData();
            City city = new City();
            city.ID = "2643743";
            city.Country = "GB";
            city.Name = "London";
            city.Lon = -0.13;
            city.Lat = 51.51;
            exeptedWeatherData.City = city;

            Location loction = new Location();
            loction.Name = "London";
            WeatherData actualWeatherData = openWeatherMapService.GetWeatherData(loction);

            Assert.IsNotNull(actualWeatherData);
            Assert.AreEqual(exeptedWeatherData.City.ID, actualWeatherData.City.ID);
            Assert.AreEqual(exeptedWeatherData.City.Country, actualWeatherData.City.Country);
            Assert.AreEqual(exeptedWeatherData.City.Name, actualWeatherData.City.Name);
            Assert.AreEqual(exeptedWeatherData.City.Lat, actualWeatherData.City.Lat);
            Assert.AreEqual(exeptedWeatherData.City.Lon, actualWeatherData.City.Lon);
        }
    }
}