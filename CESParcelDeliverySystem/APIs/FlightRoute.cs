using System;

namespace CESParcelDeliverySystem.APIs
{
    public class FlightRoute
    {
        public DateTime Date { get; set; }

        public int DurationInHours { get; set; }

        public int Price { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }
    }
}
