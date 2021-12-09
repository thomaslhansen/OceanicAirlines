using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.DTOs
{
    public class ResponseDTO
    {
        public Boolean Success { get; set; }

        public int StatusCode { get; set; }

        public Dictionary<string, Dictionary<string, string>> Payload { get; set; }

        public Boolean RoutesAreSupported { get; set; }

        public string Message { get; set; }
    }
}
