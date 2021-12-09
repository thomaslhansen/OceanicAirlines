using System;

namespace CESParcelDeliverySystem.DTOs
{
    public class ShipmentRequestDTO
    {
        public string Sort { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
