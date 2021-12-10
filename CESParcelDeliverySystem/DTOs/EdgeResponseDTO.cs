using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.DTOs
{
    public class EdgeResponseDTO
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public int PriceInDollars { get; set; }

        public int DurationInHours { get; set; }

        public string TransportMode { get; set; }

        public static implicit operator string(EdgeResponseDTO v)
        {
            throw new NotImplementedException();
        }
    }
}