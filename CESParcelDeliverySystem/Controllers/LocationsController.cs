using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.APIs;
using Microsoft.AspNetCore.Http;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {

        private readonly ILogger<LocationsController> _logger;

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return Location.GetLocationName();
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Update(Location location)
        {
            try
            {
                if (location == null)
                    return BadRequest();

                var updateLocation = Location.UpdateLocation(location);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating the location");
            }
        }
    }
}
