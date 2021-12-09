using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.DTOs;
using CESParcelDeliverySystem.Data;
using CESParcelDeliverySystem.Calculators;

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
            CesContext context = new CesContext();

            var data = context.Connection.Where(c => c.TransportationMode == "Fly");

            // Calculation to be performed here. 
            List<RouteInformationDTO> responseData = new Calculator().GetOptimalRoutes();

            var testPayload = new Dictionary<string, List<RouteInformationDTO>>();
            testPayload["routeInformation"] = responseData;

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