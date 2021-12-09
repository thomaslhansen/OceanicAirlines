using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.DTOs;

namespace CESParcelDeliverySystem.Calculators
{
    public class Calculator
    {
        public List<RouteInformationDTO> GetOptimalRoutes()
        {
            var output = new List<RouteInformationDTO>();
            for (int i = 0; i < 3; i++)
            {
                output.Add(new RouteInformationDTO
                {
                    Id = i,
                    Origin = "Test",
                    Destination = "test2",
                    PriceInDollars = 10,
                    DurationInHours = 8
                });
            }

            return output;
        }
    }
}