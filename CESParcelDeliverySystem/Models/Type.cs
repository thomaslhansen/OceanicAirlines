using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public double Fee { get; set; }
        public bool IsActive { get; set; }
    }
}
