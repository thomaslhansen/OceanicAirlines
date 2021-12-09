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
    public class UpdatePricesController : ControllerBase
    {
        private readonly ILogger<UpdatePricesController> _logger;

        public UpdatePricesController(ILogger<UpdatePricesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Post()
        {
            return "lolololoo";
        }
    }
}