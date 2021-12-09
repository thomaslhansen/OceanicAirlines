using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPricesController : ControllerBase
    {
        private readonly ILogger<GetPricesController> _logger;

        public GetPricesController(ILogger<GetPricesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get()
        {
            return 8;
        }
    }
}