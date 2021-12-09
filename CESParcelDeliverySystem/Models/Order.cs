using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Costumer Costumer { get; set; }
        public Location ToLocation { get; set; }
        public Location FromLocation { get; set; }
        public DateTime Date { get; set; }
        public bool Price { get; set; }
        public int Duration { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public bool IsCancelled { get; set; }
    }
}
