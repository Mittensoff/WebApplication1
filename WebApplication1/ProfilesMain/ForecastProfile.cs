using System;
using System.Collections.Generic;
using WebApplication1.Dto;

namespace WebApplication1.Profiles
{
    
    public class ForecastProfile : IMainMapper<BasicForecastDto, OpenWeatherForecastDaily>
    {
        public BasicForecastDto Map(OpenWeatherForecastDaily RightSideElement)
        {
            return new BasicForecastDto
            {
                TemperatureC = (decimal)RightSideElement.daily[1].temp.day,
                Rain = (decimal)RightSideElement.daily[1].rain,
                MinTemperatureC = (decimal)(RightSideElement.daily[1].temp.min - 273.15),
                MaxTemperatureC = (decimal)(RightSideElement.daily[1].temp.max - 273.15),
                Pressure = RightSideElement.daily[1].pressure,
                Humidity = RightSideElement.daily[1].humidity,
                WindSpeed = (decimal)RightSideElement.daily[1].wind_speed
            };
        }

        

        public OpenWeatherForecastDaily Map(BasicForecastDto LeftSideElement)
        {
            throw new NotImplementedException();
        }

        public List<BasicForecastDto> Map(List<OpenWeatherForecastDaily> RightSideElement)
        {
            throw new NotImplementedException();
        }   

        public List<OpenWeatherForecastDaily> Map(List<BasicForecastDto> LeftSideElement)
        {
            throw new NotImplementedException();
        }
    }

    
}



