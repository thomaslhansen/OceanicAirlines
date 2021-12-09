using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.APIs
{
    public class Price
    {
        public string DimensionCategory { get; set; }

        public string WeightCategory { get; set; }

        public int PriceInDollars { get; set; }
    }
}
