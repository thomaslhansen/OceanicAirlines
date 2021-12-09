using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public Location(int id, string name, bool isActive)
        {
            this.Id = id;
            this.Name = name;
            this.IsActive = isActive;
        }
    }
}
