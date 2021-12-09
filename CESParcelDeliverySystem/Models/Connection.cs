using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public Location ToLocation { get; set; }
        public Location FromLocation { get; set; }
        public bool IsActive { get; set; }
    }
}
