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

        private readonly MainContext _mainContext;
        private readonly ILogger<OpenWeatherController> _logger;
        private readonly OpenWeatherService _openWeatherClient;
        private readonly MailNotifierService _mailNotifierService;
        private readonly IMainMapper<BasicForecastDto, OpenWeatherForecastDaily> _mainMapper;
        public OpenWeatherController(ILogger<OpenWeatherController> logger,  OpenWeatherService OpenWeatherClient, MailNotifierService mailNotifierService,
        IMainMapper<BasicForecastDto, OpenWeatherForecastDaily> mainMapper, MainContext mainContext)
        {
            _mainContext = mainContext;
            _logger = logger;
            _openWeatherClient = OpenWeatherClient;
            _mailNotifierService = mailNotifierService;
            _mainMapper = mainMapper;

        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="City"></param>
        /// <returns>Current Weather </returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>    
        [HttpGet]
        [Route("OpenWeather/current_weather")]
        [ProducesResponseType(200, Type=typeof(BasicCurrentWeatherDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(string City)
        {
            if (City != "")
            {
                var currentWeather = await _openWeatherClient.GetCurrentWeather(City);
                await _mailNotifierService.NotifyGidra("asdf", "asdfasdffdaafsddfs");
                var forecast = new Models.Forecast()
                {

                };

                

        _mainContext.Add(forecast);
                _mainContext.SaveChanges();
                return Ok(currentWeather);
            }
            return BadRequest(); 

        }
        
        /// <summary>
        /// Get prognozu
        /// </summary>
        /// <param name="lat"> latitjud</param>
        /// <param name="lon"> longitjud</param>
        /// <returns></returns>
        [HttpGet]
        [Route("OpenWeather/forecast")]
        [ProducesResponseType(200, Type = typeof(BasicForecastDto))]
        [ProducesResponseType(400)]
        // Task<ActionResult<BasicForecastDto>>
        public async Task<IActionResult> Get(decimal lat, decimal lon)
        {   
            if (lat == 0 || lon == 0)
            {
                return BadRequest();
            }
            var forecast = await _openWeatherClient.GetForecast(lat, lon);
            return Ok(forecast);
        }
         
    }
}
