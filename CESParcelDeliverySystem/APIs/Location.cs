using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.Data;

namespace CESParcelDeliverySystem.APIs
{
    public class Location
    {
        public static CesContext Context = new CesContext();
        public string LocationName { get; set; }

        public int LocationId { get; set; }

        public bool Status { get; set; }

        public Location(int id, string LocationName, bool Status)
        {
            this.LocationId = id;
            this.LocationName = LocationName;
            this.Status = Status;
        }

        public static List<Location> GetLocationName()
        {
            var locations = Context.Location;
            List<Location> result = new List<Location>();
            foreach (var item in locations)
            {
                result.Add(new Location(item.Id, item.Name,item.IsActive));
            }
            return result;
        }
    }
}