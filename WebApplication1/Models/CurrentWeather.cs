using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CurrentWeather
    {
        public int Id { get; set; }
        public string WeatherDescription { get; set; }
        public decimal TemperatureK { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
    }
}
