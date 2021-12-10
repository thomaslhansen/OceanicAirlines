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
            var order = new Order(1, "Hans", "Hans@mail.com", "ABBA",
                "AB", DateTime.Now, 200, 20, 20, 20, 20, false);
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
        public void CreateOrderTrueTest()
        {
            var order = new Order(1, "Hans", "Hans@mail.com", "ABBA",
                "AB", DateTime.Now, 200, 20, 20, 20, 20, false);
            var result = Order.CreateOrder(order);
            Assert.IsTrue(result);
        }
    }
}