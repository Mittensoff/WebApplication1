using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;

namespace WebApplication1.Profiles
{
    public class CurrentWeatherProfile : MainMapper<BasicCurrentWeatherDto, OpenWeatherCurrentWeatherDto>
    {
        public override Dto.BasicCurrentWeatherDto Map(OpenWeatherCurrentWeatherDto RightSideElement)
        {
            return new BasicCurrentWeatherDto
            {
                WeatherDescription = RightSideElement.weather.FirstOrDefault().description,
                Humidity = RightSideElement.main.humidity,
                TemperatureC = (decimal)(RightSideElement.main.temp - 273.15),
                TemperatureK = (decimal)RightSideElement.main.temp,
                Pressure = RightSideElement.main.pressure,
                WindSpeed = (decimal)RightSideElement.wind.speed
            };
        }

        public override OpenWeatherCurrentWeatherDto Map(Dto.BasicCurrentWeatherDto LeftSideElement)
        {
            throw new NotImplementedException();
        }

     }
}
