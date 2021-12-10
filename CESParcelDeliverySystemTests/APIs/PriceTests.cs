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
    public class PriceTests
    {
        [TestMethod()]
        public void PriceTestTrue()
        {
            var price = new Price(1, "A", "Light", 40, 80, 80);
            Assert.IsNotNull(price);
        }

        [TestMethod()]
        public void GetPricesTest()
        {
            var price = Price.GetPrices();
            Assert.IsNotNull(price);
        }
    }
}