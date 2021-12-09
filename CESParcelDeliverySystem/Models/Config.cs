using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Config
    {
        public int Id { get; set; }
        public int DurationInHours { get; set; }
        public int MaxWeight { get; set; }
        public int MaxDimension { get; set; }
    }
}
