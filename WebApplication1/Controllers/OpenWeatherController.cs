using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApplication1.Dto;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController] 
    public class OpenWeatherController : ControllerBase
    {

        private readonly ILogger<OpenWeatherController> _logger;
        private readonly OpenWeatherService _openWeatherClient;
        private readonly MailNotifierService _mailNotifierService;
        public OpenWeatherController(ILogger<OpenWeatherController> logger, OpenWeatherService OpenWeatherClient, MailNotifierService mailNotifierService)
        {
            _logger = logger;
            _openWeatherClient = OpenWeatherClient;
            _mailNotifierService = mailNotifierService;
        }

        [HttpGet]
        [Route("OpenWeather/current_weather")]
        public async Task<BasicCurrentWeatherDto> Get(string City)
        { 
            var currentWeather = await _openWeatherClient.GetCurrentWeather(City);
            await _mailNotifierService.NotifyGidra("asdf", "asdfasdffdaafsddfs");
            return currentWeather;
        }
        
        [HttpGet]
        [Route("OpenWeather/forecast")]
        public async Task<BasicForecastDto> Get(decimal lat, decimal lon)
        {
            var forecast = await _openWeatherClient.GetForecast(lat, lon);
            return forecast;
        }
        //GetForecast
    }
}
