using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CESParcelDeliverySystem.Data;
using CESParcelDeliverySystem.Models;

namespace CESParcelDeliverySystem.APIs
{
    public class Order
    {
        public static CesContext Context = new CesContext();
        public int Id { get; set; }
        public string ToLocation { get; set; }
        public string FromLocation { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string CostumerName { get; set; }
        public string CostumerEmail { get; set; }
        public bool IsCancelled { get; set; }

        public Order(int id, string CostumerName, string CostumerEmail, string ToLocation,
            string FromLocation, DateTime date,
            int price,
            int duration, int height, int length, int width, bool isCancelled)
        {
            this.Id = id;
            this.CostumerEmail = CostumerEmail;
            this.ToLocation = ToLocation;
            this.FromLocation = FromLocation;
            this.Date = date;
            this.Price = price;
            this.Duration = duration;
            this.Height = height;
            this.Length = length;
            this.Width = width;
            this.IsCancelled = isCancelled;
        }

        public static List<Order> GetOrder()
        {
            var orders =
                Context.Order.ToList();
            var result = new List<Order>();
            foreach (var order in orders)
            {
                var ToLocation = Context.Location.FirstOrDefault((x => x.Id == order.ToLocation));
                var FromLocation = Context.Location.FirstOrDefault((x => x.Id == order.FromLocation));
                result.Add(new Order(order.Id, order.CostumerName, order.CostumerEmail, ToLocation.Name, FromLocation.Name,
                    order.Date,
                    order.Price, order.Duration,
                    order.Height, order.Length, order.Width, order.IsCancelled));
            }

            return result;
        }

        public static bool CreateOrder(Order order)
        {
            if (order != null)
            {
                var mOrder = new Models.Order
                {
                    CostumerName = order.CostumerName,
                    CostumerEmail = order.CostumerEmail,
                    Price = order.Price,
                    Date = order.Date,
                    Duration = order.Duration,
                    FromLocation = Context.Location.FirstOrDefault(x => x.Name.Equals(order.FromLocation)).Id,
                    ToLocation = Context.Location.FirstOrDefault(x => x.Name.Equals(order.ToLocation)).Id,
                    Height = order.Height,
                    Length = order.Length,
                    Width = order.Width,
                    IsCancelled = false,
                };

                Context.Order.Add(mOrder);
                Context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}