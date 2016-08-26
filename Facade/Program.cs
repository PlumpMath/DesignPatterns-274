using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            const string zipCode = "560037";
            var localTemp = new TemperatureLookupFacade().GetLocalTemperature(zipCode);
            Console.WriteLine("State :{0}",localTemp.State);
            Console.WriteLine("City :{0}", localTemp.City);
            Console.WriteLine("Celcius :{0}", localTemp.Celcius);
            Console.WriteLine("Farenheit :{0}", localTemp.Farenhiet.Value);

            Console.ReadLine();
        }
    }
    public class LocalTemperature
    {
        public string City { get; set; }
        public string State { get; set; }

        public Farenheit Farenhiet { get; set; }
        public Double Celcius { get; set; }
    }
    public class TemperatureLookupFacade
    {
        private WeatherService _WeatherService;
        private GeoLookupService _GeoLookupService;
        private EnglishMetricConverter _EnglishMetricConverter;

        public TemperatureLookupFacade()
        {
            _WeatherService = new WeatherService();
            _GeoLookupService = new GeoLookupService();
            _EnglishMetricConverter = new EnglishMetricConverter();
        }
        public TemperatureLookupFacade(WeatherService WeatherService, GeoLookupService GeoLookupService, EnglishMetricConverter EnglishMetricConverter)
        {
            _WeatherService = WeatherService;
            _GeoLookupService = GeoLookupService;
            _EnglishMetricConverter = EnglishMetricConverter;
        }

        public LocalTemperature GetLocalTemperature(string ZipCode)
        {
            var city = _GeoLookupService.GetCity(ZipCode);
            var state = _GeoLookupService.GetState(ZipCode);

            var coords = _GeoLookupService.GetCoordinates(ZipCode);

            var farenheit = _WeatherService.GetTemperature(coords.Longitude, coords.Latitude);
            var celcius = _EnglishMetricConverter.FarenheitToCelcius(farenheit.Value);


            return new LocalTemperature()
            {
                City = city,
                Celcius = celcius,
                Farenhiet = farenheit,
                State = state
            };
        }
    }
}
