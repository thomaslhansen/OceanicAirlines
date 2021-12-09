using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.APIs;
using Microsoft.AspNetCore.Http;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExportDataController : ControllerBase
    {

        private readonly ILogger<ExportDataController> _logger;

        public ExportDataController(ILogger<ExportDataController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult MyExportAction(DateTime to, DateTime from)
        {
            return File(ExportData.Export(to, from), "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");
        }
    }
}