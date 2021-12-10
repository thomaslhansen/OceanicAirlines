using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.DTOs;

namespace CESParcelDeliverySystem.BusinessLogic
{
    public class RouteSorter
    {
        public List<EdgeResponseDTO> EdgeResponseDtos { get; set; }
        public string StartLocation { get; set; }
        public RouteSorter(List<EdgeResponseDTO> input, string startLocation)
        {
            EdgeResponseDtos = input;
            StartLocation = startLocation;
        }

        public List<EdgeResponseDTO> ExecuteImplementation()
        {
            string nextSearch = StartLocation;
            var output = new List<EdgeResponseDTO>();
            for (var i = 0; i < EdgeResponseDtos.Count; i++)
            {
                var obj = EdgeResponseDtos.First(e => e.Origin == nextSearch);
                output.Add(obj);
                nextSearch = obj.Destination;
            }
            return output;
        }
    }
}
