using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class OrderType
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Type Type { get; set; }

    }
}
