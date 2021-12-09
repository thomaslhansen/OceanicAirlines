using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CESParcelDeliverySystem.BusinessLogic
{
    public class ParcelMapper
    {
        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }
        public string EvaluateWeightClass()
        {
            if (Weight < 1000)
            {
                return "light";
            } else if (Weight <= 5000)
            {
                return "medium";
            } else if (Weight <= 20000 )
            {
                return "heavy";
            }
            else
            {
                return "unsupported";
            }
        }

        public string EvaluateSizeClass()
        {
            var minimum = new List<int> {Height, Height, Width}.Min();
            if (minimum > 200)
            {
                return "unsupported";
            }
            else if (minimum >= 40)
            {
                return "C";
            }
            else if (minimum >= 25)
            {
                return "B";
            }
            else
            {
                return "A";
            }
        }

    }

    
}
