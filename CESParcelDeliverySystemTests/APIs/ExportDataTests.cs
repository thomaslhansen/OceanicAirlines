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
    public class ExportDataTests
    {
        [TestMethod()]
        public void ExportTest()
        {
            var export = ExportData.Export(DateTime.Now, DateTime.UtcNow);
            Assert.IsNotNull(export);
        }
    }
}