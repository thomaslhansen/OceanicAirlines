using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.DTOs
{
    public class EdgeDTO
    {
        public int Origin { get; set; }

        public int Destination { get; set; }

        public int PriceInDollars { get; set; }

        public int DurationInHours { get; set; }

        public string TransportMode { get; set; }
    }
}