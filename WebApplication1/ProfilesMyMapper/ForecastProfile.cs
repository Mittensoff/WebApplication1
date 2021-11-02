using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dto;
using WebApplication1.Models;
namespace WebApplication1.ProfilesMyMapper
{
    public class ForecastProfile : IMyMapper<BasicForecastDto, OpenWeatherForecastDaily>, IMyMapper<BasicForecastDto, Forecast>
    {
        public BasicForecastDto Map(OpenWeatherForecastDaily Second)
        {
            return new BasicForecastDto
            {
                TemperatureC = (decimal)Second.daily[1].temp.day,
                Rain = (decimal)Second.daily[1].rain,
                MinTemperatureC = (decimal)(Second.daily[1].temp.min - 273.15),
                MaxTemperatureC = (decimal)(Second.daily[1].temp.max - 273.15),
                Pressure = Second.daily[1].pressure,
                Humidity = Second.daily[1].humidity,
                WindSpeed = (decimal)Second.daily[1].wind_speed
            };
        }

        public OpenWeatherForecastDaily Map(BasicForecastDto First)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BasicForecastDto> Map(IEnumerable<OpenWeatherForecastDaily> Second)
        {
            foreach (var elemSecond in Second)
            {
                yield return Map(elemSecond);
            }
        }

        public IEnumerable<OpenWeatherForecastDaily> Map(IEnumerable<BasicForecastDto> First)
        {
            throw new NotImplementedException();
        }

        public BasicForecastDto Map(Forecast Second)
        {
            return new BasicForecastDto
            {
                WindSpeed = Second.WindSpeed,
                Humidity = Second.Humidity,
                MaxTemperatureC = Second.MaxTemperatureC,
                MinTemperatureC = Second.MinTemperatureC,
                Pressure = Second.Pressure,
                Rain = Second.Rain,
                TemperatureC = Second.TemperatureC
            };
        }

        public IEnumerable<BasicForecastDto> Map(IEnumerable<Forecast> Second)
        {
            foreach(var elemSecond in Second)
            {
                yield return Map(elemSecond);
            }
        }

        Forecast IMyMapper<BasicForecastDto, Forecast>.Map(BasicForecastDto First)
        {
            return new Forecast
            {
                WindSpeed = First.WindSpeed,
                Humidity = First.Humidity,
                MaxTemperatureC = First.MaxTemperatureC,
                MinTemperatureC = First.MinTemperatureC,
                Pressure = First.Pressure,
                Rain = First.Rain,
                TemperatureC = First.TemperatureC
            };
        }

        IEnumerable<Forecast> IMyMapper<BasicForecastDto, Forecast>.Map(IEnumerable<BasicForecastDto> First)
        {
            foreach(var elemFirst in First)
            {
                yield return ((IMyMapper<BasicForecastDto, Forecast>)this).Map(elemFirst); //hm
            }
        }
    }
}
