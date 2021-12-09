﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.APIs;

namespace CESParcelDeliverySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLocationsController : ControllerBase
    {

        private readonly ILogger<GetLocationsController> _logger;

        public GetLocationsController(ILogger<GetLocationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Location
            {
                    LocationName = "teste",
                    LocationId = 3,
                    status = true

            })
                .ToArray();
        }
    }
}
