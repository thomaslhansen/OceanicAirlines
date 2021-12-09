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
    public class PricesController : ControllerBase
    {
        private readonly ILogger<PricesController> _logger;

        public PricesController(ILogger<PricesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Price> Get()
        {
            return Price.GetPrices();
        }

        [HttpPost]
        public async Task<ActionResult<Price>> Update(Price price)
        {
            try
            {
                if (price == null)
                    return BadRequest();

                var updatedPrice = Price.UpdatePrice(price);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating the price");
            }
        }
    }
}