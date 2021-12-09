using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.BusinessLogic;
using CESParcelDeliverySystem.DTOs;
using CESParcelDeliverySystem.Data;
using CESParcelDeliverySystem.Calculators;
using CESParcelDeliverySystem.BusinessLogic.RoutePlanner;
using Microsoft.AspNetCore.Http;

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
            context.ChangeTracker.LazyLoadingEnabled = true;

            // Set up start - stop points
            int toId = 26;
            int fromId = 11;


            // Get pricing info
            var parcelMapper = new ParcelMapper(); // Use this
            string sizeCategory = "A";
            string weightCategory = "light";

            var x = context.Pricing.First(p => p.SizeCategory == sizeCategory && p.WeightCategory == weightCategory);

            Dictionary<string, double> basePrices = new Dictionary<string, double>();
            basePrices["shipping"] = Convert.ToDouble(x.LatestShippingPrice);
            basePrices["trucking"] = Convert.ToDouble(x.LatestTruckingPrice);
            basePrices["fly"] = Convert.ToDouble(x.Price);

            Dictionary<string, int> baseDurations = new Dictionary<string, int>();
            baseDurations["shipping"] = 12;
            baseDurations["trucking"] = 4;
            baseDurations["fly"] = 8;

            double? multiplier = context.Type.First(m => m.ContentType == "Weapons").Fee;

            if (multiplier != null)
            {
                basePrices["fly"] = basePrices["fly"] * Convert.ToDouble(multiplier);
            }

            // Set up network
            //int nodes = context.Connection.Where(c => c.TransportationMode == "Fly").Select(f => f.ToLocation).Distinct().Count();
            var network = context.Connection.Where(c => c.TransportationMode == "Fly");
            int nodes = 26;

            List<EdgeDTO> edges = new List<EdgeDTO>();

            foreach (var edge in network)
            {
                string _type = edge.TransportationMode.ToLower();
                EdgeDTO edgeDto = new EdgeDTO();
                edgeDto.Destination = edge.FromLocation;
                edgeDto.Destination = edge.ToLocation;
                edgeDto.PriceInDollars = Convert.ToInt32(Convert.ToDouble(edge.Moves) * basePrices[_type]);
                edgeDto.DurationInHours = edge.Moves * baseDurations[_type];
                edgeDto.TransportMode = _type;
                edges.Add(edgeDto);
            }

            // Calculation to be performed here. 
            var calc = new Planner(nodes, edges, fromId, toId);
            var result = calc.Plan();

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

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> Update(ShipmentRequestDTO shipmentRequest)
        {
            try
            {
                if (shipmentRequest == null)
                    return BadRequest();

                CesContext context = new CesContext();
                var ss = shipmentRequest;

                int toId = context.Location.First(c => c.Name == shipmentRequest.To).Id;
                int fromId = context.Location.First(c => c.Name == shipmentRequest.From).Id;

                var parcelMapper = new ParcelMapper
                {
                    Height = shipmentRequest.Height,
                    Length = shipmentRequest.Length,
                    Weight = shipmentRequest.Weight,
                    Width = shipmentRequest.Width
                };

                string sizeCategory = parcelMapper.EvaluateSizeClass();
                string weightCategory = parcelMapper.EvaluateWeightClass();

                var x = context.Pricing.First(p => p.SizeCategory == sizeCategory && p.WeightCategory == weightCategory);

                Dictionary<string, double> basePrices = new Dictionary<string, double>();
                basePrices["boat"] = Convert.ToDouble(x.LatestShippingPrice);
                basePrices["truck"] = Convert.ToDouble(x.LatestTruckingPrice);
                basePrices["fly"] = Convert.ToDouble(x.Price);

                Dictionary<string, int> baseDurations = new Dictionary<string, int>();
                baseDurations["boat"] = 12;
                baseDurations["truck"] = 4;
                baseDurations["fly"] = 8;

                var multiplier = context.Type.FirstOrDefault(m => m.ContentType == shipmentRequest.Type);
                
                if (multiplier != null)
                {
                    basePrices["fly"] = basePrices["fly"] * Convert.ToDouble(multiplier.Fee);
                }

                // Set up network
                var toNodes = context.Connection.Select(f => f.ToLocation).Distinct().ToList();
                var fromNodes = context.Connection.Select(f => f.FromLocation).Distinct().ToList();
                var finalNodes = toNodes.Concat(fromNodes);
                var nodes = finalNodes.Distinct().ToList();

                Dictionary<int, int> mappingDict = new Dictionary<int, int>();

                for (var i = 0; i < nodes.Count; i++)
                {
                    mappingDict[nodes[i]] = i;
                }

                var network = context.Connection.ToList();

                List<EdgeDTO> edges = new List<EdgeDTO>();

                foreach (var edge in network)
                {
                    string _type = edge.TransportationMode.ToLower();
                    EdgeDTO edgeDto = new EdgeDTO
                    {
                        Origin = mappingDict[edge.FromLocation],
                        Destination = mappingDict[edge.ToLocation],
                        PriceInDollars = Convert.ToInt32(Convert.ToDouble(edge.Moves) * basePrices[_type]),
                        DurationInHours = edge.Moves * baseDurations[_type],
                        TransportMode = _type,
                    };
                    edges.Add(edgeDto);
                }

                // Calculation to be performed here. 
                var calc = new Planner(nodes.Count, edges, fromId, toId);
                var result = calc.Plan();

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

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error calculating data");
            }
        }
    }
}