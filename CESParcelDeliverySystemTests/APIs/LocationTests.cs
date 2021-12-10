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
    public class LocationTests
    {
        [TestMethod()]
        public void LocationTest()
        {
            var location = Location.GetLocationName();
            Assert.IsNotNull(location);
        }
    }
}