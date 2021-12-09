using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CESParcelDeliverySystem.Data
{
    public class CesContext : DbContext
    {
        public virtual DbSet<Costumer> Costumer { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Pricing> Pricing { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<Models.Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:dbs-oa-dk2.database.windows.net,1433;Initial Catalog=db-oa-dk2;Persist Security Info=False;User ID=admin-oa-dk2;Password=oceanicFlyAway16;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
    }
}
