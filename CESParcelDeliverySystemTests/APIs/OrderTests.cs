using Microsoft.VisualStudio.TestTools.UnitTesting;
using CESParcelDeliverySystem.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.APIs.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void OrderTest()
        {
            var order = new Order(1, "Hans", "Hans@mail.com", new Models.Location(1, "ABBA", false),
                new Models.Location(2, "AB", true), DateTime.Now, 200, 20, 20, 20, 20, false);
            Assert.IsNotNull(order);
        }

        [TestMethod()]
        public void GetOrderTest()
        {
            var orders = Order.GetOrder();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count != 0);
        }

        [TestMethod()]
        public void CreateOrderFalseTest()
        {
            var order = new Models.Order();
            order.CostumerEmail = "Hans@mail.com";
            order.CostumerName = "Hans Hansen";
            var result = Order.CreateOrder(order);
            Assert.IsTrue(result);
        }
    }
}