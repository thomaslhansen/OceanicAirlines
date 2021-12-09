using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ToLocation { get; set; }
        public int FromLocation { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}
