using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public int ToLocation { get; set; }
        public int FromLocation { get; set; }
        public int Moves { get; set; }
        public string TransportationMode { get; set; }
        public bool IsActive { get; set; }
    }
}
