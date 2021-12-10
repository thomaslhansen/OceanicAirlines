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
                var network = context.Connection.ToList();
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

                var multiplier = context.Type.FirstOrDefault(m => m.ContentType.ToLower() == shipmentRequest.Type.ToLower());
                if (multiplier != null)
                {
                    if (multiplier.Fee == null)
                    {
                        network = network.Where(n => n.TransportationMode.ToLower() != "fly").ToList();
                    }
                    else
                    {
                        basePrices["fly"] = basePrices["fly"] * (Convert.ToDouble(multiplier.Fee) / 100 + 1);
                    }
                }

                // Handling trucking edgecases
                if (shipmentRequest.Type.ToLower() == "recorded delivery")
                {
                    basePrices["truck"] = basePrices["truck"] + 10;
                }
                if (shipmentRequest.Type.ToLower() == "live animals")
                {
                    basePrices["truck"] = basePrices["truck"] * 1.5;
                }
                if (shipmentRequest.Type.ToLower() == "cautious parcels")
                {
                    basePrices["truck"] = basePrices["truck"] * 1.75;
                }
                if (shipmentRequest.Type.ToLower() == "refrigerated goods")
                {
                    basePrices["truck"] = basePrices["truck"] * 1.1;
                }

                // Set up network
                var toNodes = context.Connection.Select(f => f.ToLocation).Distinct().ToList();
                var fromNodes = context.Connection.Select(f => f.FromLocation).Distinct().ToList();
                var finalNodes = toNodes.Concat(fromNodes);
                var nodes = finalNodes.Distinct().ToList();

                Dictionary<int, int> mappingDict = new Dictionary<int, int>();
                Dictionary<int, int> inverseMappingDict = new Dictionary<int, int>();

                for (var i = 0; i < nodes.Count; i++)
                {
                    mappingDict[nodes[i]] = i;
                    inverseMappingDict[i] = nodes[i];
                }

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
                var calc = new Planner(nodes.Count, edges, mappingDict[fromId], mappingDict[toId]);
                var result = calc.Plan();

                Dictionary<string, List<EdgeResponseDTO>> final_ = new Dictionary<string, List<EdgeResponseDTO>>();
                var outputList = new List<SolutionDTO>();

                foreach (SearchNode n in result)
                {
                    Guid g = Guid.NewGuid();

                    final_[g.ToString()] = new List<EdgeResponseDTO>();
                    foreach (var e in n.Route())
                    {
                        EdgeResponseDTO newd = new EdgeResponseDTO
                        {
                            PriceInDollars = Convert.ToInt32(e.Cost()),
                            DurationInHours = Convert.ToInt32(e.Time()),
                            Origin = context.Location.First(c => c.Id == inverseMappingDict[e.Source()]).Name,
                            Destination = context.Location.First(c => c.Id == inverseMappingDict[e.Target(e.Source())]).Name,
                            TransportMode = e.GetType().ToString()
                        };
                        final_[g.ToString()].Add(newd);
                    }
                    SolutionDTO solution = new SolutionDTO
                        {
                            Solution = final_[g.ToString()],
                            PriceInDollars = Convert.ToInt32(n.Cost()),
                            DurationInHours = Convert.ToInt32(n.Time())
                        };
                    outputList.Add(solution);
                }

                foreach (var elem in outputList)
                {
                    var allDtos = elem.Solution;
                    var sorter = new RouteSorter(allDtos, shipmentRequest.From);
                    elem.Solution = sorter.ExecuteImplementation();
                }

                if (shipmentRequest.Sort.ToLower() == "fastest")
                {
                    outputList = outputList.OrderByDescending(o => o.PriceInDollars).ToList();
                }
                if (shipmentRequest.Sort.ToLower() == "cheapest")
                {
                    outputList = outputList.OrderByDescending(o => o.DurationInHours).ToList();
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