using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string SizeCategory { get; set; }
        public string WeightCategory { get; set; }
        public int Price { get; set; }
        public int LatestShippingPrice { get; set; }
        public int LatestTruckingPrice { get; set; }
    }
}
