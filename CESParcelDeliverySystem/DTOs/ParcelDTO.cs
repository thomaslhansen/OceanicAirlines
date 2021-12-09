using System;
using System.Collections.Generic;

namespace CESParcelDeliverySystem.DTOs
{
    public class ParcelDTO
    {
        public DateTime Date { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
        
        public int Depth { get; set; }

        public Dictionary<String, Boolean> Details { get; set; }

        public List<Dictionary<String, String>> RequestedRoutes { get; set; }
    }
}
