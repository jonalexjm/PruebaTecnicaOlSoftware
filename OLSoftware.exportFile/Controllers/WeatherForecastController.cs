using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OLSoftware.exportFile.Data;

namespace OLSoftware.exportFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly dbOlSoftwareContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
                                        dbOlSoftwareContext bOlSoftwareContext)
        {
            _logger = logger;
            _context = bOlSoftwareContext;
        }

        //[HttpGet]
        //public async Task<User> Get()
        //{

        //    var result = await _context.User.Include(x => x.UserProject != null).ToListAsync();


        //   // return Ok(result);
        //}
    }
}
