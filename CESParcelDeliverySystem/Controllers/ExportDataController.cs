using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CESParcelDeliverySystem.APIs;
using CESParcelDeliverySystem.Data;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportDataController : ControllerBase
    {
        private readonly ILogger<ExportDataController> _logger;
        public static CesContext Context = new CesContext();

        public ExportDataController(ILogger<ExportDataController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<ExportData> ExportData(DateTime to, DateTime from)
        {
            try
            {
                var orders = Context.Order.Where(o => o.Date < to && o.Date > from)
                    .ToList();

                var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
                var ms = new MemoryStream();

                var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true));

                var cw = new CsvWriter(sw, cc);

                cw.WriteRecords(orders);


                return File(ms, "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating the report");
            }
        }
    }
}