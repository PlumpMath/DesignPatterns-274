using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class WeatherService
    {
        public Farenheit GetTemperature(long Longitude, long Latitude)
        {
            return new Farenheit() { Value = 68 };
        }
    }
    public class GeoLookupService
    {
        public Coordinate GetCoordinates(string ZipCode)
        {
            return new Coordinate() { Latitude = 1002545, Longitude = 253775444 };
        }
        public string GetState(string Zipcode)
        {
            return "Karnataka";
        }
        public string GetCity(string Zipcode)
        {
            return "Bangalore";
        }


    }
    public class EnglishMetricConverter
    {
        public double FarenheitToCelcius( double Farenheit)
        {
            return ((Farenheit - 32) * 5) / 9;
        }
    }
}
