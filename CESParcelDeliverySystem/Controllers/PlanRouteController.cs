using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.DTOs;

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
        public ResponseDTO Get()
        {
            var testPayload = new Dictionary<string, List<RouteInformationDTO>>();

            testPayload["routeInformation"] = new List<RouteInformationDTO>();

            var testRouteInformation = new RouteInformationDTO
            {
                Id = 1,
                Origin = "city",
                Destination = "sdf",
                PriceInDollars = 40,
                DurationInHours = 8
            };

            testPayload["routeInformation"].Add(testRouteInformation);

            var response = new ResponseDTO
            {
                Success = true,
                StatusCode = 200,
                Payload = testPayload,
                RoutesAreSupported = true,
                Message = "200 - OK"

            };

            return response;
        }
    }
}