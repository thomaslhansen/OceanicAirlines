using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CESParcelDeliverySystem.Data;
using CsvHelper;
using CsvHelper.Configuration;

namespace CESParcelDeliverySystem.APIs
{
    public class ExportData
    {
        public static CesContext Context = new CesContext();

        public static Stream Export(DateTime to, DateTime from)
        {
            var orders = Context.Order.Where(o => o.Date < to && o.Date > from)
                .ToList();

            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(orders);
                    } // The stream gets flushed here.

                    return ms;
                }
            }
        }
    }
}