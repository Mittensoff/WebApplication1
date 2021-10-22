using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;

namespace WebApplication1.Profiles
{
    public class CurrentWeatherProfile : IMainMapper<BasicCurrentWeatherDto, OpenWeatherCurrentWeatherDto>
    {
        public BasicCurrentWeatherDto Map(OpenWeatherCurrentWeatherDto RightSideElement)
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

        public  OpenWeatherCurrentWeatherDto Map( BasicCurrentWeatherDto LeftSideElement)
        {
            throw new NotImplementedException();
        }
        
        public List<BasicCurrentWeatherDto> Map(List<OpenWeatherCurrentWeatherDto> RightSideElement)
        {
            throw new NotImplementedException();
        }

        public List<OpenWeatherCurrentWeatherDto> Map(List<BasicCurrentWeatherDto> LeftSideElement)
        {
            throw new NotImplementedException();
        }
     }
}
