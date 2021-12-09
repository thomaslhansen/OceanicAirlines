using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Location ToLocation { get; set; }
        public Location FromLocation { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
    }
}
