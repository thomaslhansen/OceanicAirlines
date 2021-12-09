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
    public class PlanRouteController : ControllerBase
    {
        private readonly ILogger<PlanRouteController> _logger;

        public PlanRouteController(ILogger<PlanRouteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "lolololoo";
        }
    }
}