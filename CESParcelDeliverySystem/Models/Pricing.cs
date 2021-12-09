using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}
