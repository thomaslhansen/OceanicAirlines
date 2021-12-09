using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.DTOs
{
    public class RouteInformationDTO
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public int PriceInDollars { get; set; }

        public int DurationInHours { get; set; }

    }
}