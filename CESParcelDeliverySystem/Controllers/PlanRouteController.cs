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

                Dictionary<string, List<EdgeDTO>> final_ = new Dictionary<string, List<EdgeDTO>>();

                foreach (SearchNode n in result)
                {
                    Guid g = Guid.NewGuid();

                    final_[g.ToString()] = new List<EdgeDTO>();
                    foreach (var e in n.Route())
                    {
                        EdgeDTO newd = new EdgeDTO
                        {
                            PriceInDollars = Convert.ToInt32(e.Cost()),
                            DurationInHours = Convert.ToInt32(e.Time()),
                            Origin = e.Source(),
                            Destination = e.Target(e.Source()),
                            TransportMode = e.GetType().ToString()
                        };

                        final_[g.ToString()].Add(newd);
                    }
                }


                var outputList = new List<List<EdgeDTO>>();

                foreach (var elem in final_)
                {
                    outputList.Add(elem.Value);
                }


                var response = new ResponseDTO
                {
                    Success = true,
                    StatusCode = 200,
                    Payload = outputList,
                    RoutesAreSupported = true,
                    Message = "200 - OK"
                };

                return response;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error calculating data");
            }
        }
    }
}