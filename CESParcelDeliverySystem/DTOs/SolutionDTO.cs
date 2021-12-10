using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.DTOs;

namespace CESParcelDeliverySystem.DTOs
{
    public class SolutionDTO
    {
        public List<EdgeResponseDTO> Solution { get; set; }

        public int PriceInDollars { get; set; }

        public int DurationInHours { get; set; }
    }
}
