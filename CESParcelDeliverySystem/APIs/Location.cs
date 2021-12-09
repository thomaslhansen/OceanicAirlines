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
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public Location(int id, string name, bool status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
        }

        public static List<Location> GetLocationName()
        {
            var locations = Context.Location;
            List<Location> result = new List<Location>();
            foreach (var item in locations)
            {
                result.Add(new Location(item.Id, item.Name, item.IsActive));
            }

            return result;
        }

        public static bool UpdateLocation(Location location)
        {
            var update = Context.Location.FirstOrDefault(x => x.Id == location.Id);
            if (update == null)
                return false;

            update.Name = location.Name;
            update.IsActive = location.Status;
            Context.Update(update);
            Context.SaveChanges();
            return true;
        }
    }
}