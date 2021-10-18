using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dto
{
    public class BasicCurrentWeatherDto
    {
        public string WeatherDescription { get; set; }
        public decimal TemperatureK { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal Pressure { get;set;  } 
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; } 
    }

    public class BasicForecastDto
    {
        public decimal TemperatureC { get; set; }
        public decimal Rain { get; set; }
        public decimal MinTemperatureC { get; set; }
        public decimal MaxTemperatureC { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
    }

}
