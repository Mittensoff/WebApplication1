using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Forecast
    {
        public int Id { get; set; }
        public decimal TemperatureC { get; set; }
        public decimal Rain { get; set; }
        public decimal MinTemperatureC { get; set; }
        public decimal MaxTemperatureC { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public decimal WindSpeed { get; set; }
    }
}
