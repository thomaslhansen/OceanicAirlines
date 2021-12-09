using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.APIs;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightStatusController : ControllerBase
    {


        private readonly ILogger<FlightStatusController> _logger;

        public FlightStatusController(ILogger<FlightStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FlightRoute> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FlightRoute
                {
                    Date = DateTime.Now.AddDays(index),
                    DurationInHours = 8,
                    Price = 20,
                    Origin = "s",
                    Destination = "sdf"
                })
                .ToArray();
        }
    }
}
