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
    public class UpdateLocationController : ControllerBase
    {
        private readonly ILogger<UpdateLocationController> _logger;

        public UpdateLocationController(ILogger<UpdateLocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Post()
        {
            return "hej";
        }
    }
}