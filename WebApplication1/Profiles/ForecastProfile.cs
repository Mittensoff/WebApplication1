using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;

namespace WebApplication1.Profiles
{
    public class ForecastProfile : MainMapper<BasicForecastDto, OpenWeatherForecastDaily>
    {
        public override BasicForecastDto Map(OpenWeatherForecastDaily RightSideElement)
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

        public override OpenWeatherForecastDaily Map(BasicForecastDto LeftSideElement)
        {
            throw new NotImplementedException();
        }
    }
}
