using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Costumer { get; set; }
        public  int ToLocation { get; set; }
        public  int FromLocation { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public bool IsCancelled { get; set; }

    }
}
