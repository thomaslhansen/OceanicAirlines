using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CESParcelDeliverySystem.Data;

namespace CESParcelDeliverySystem.APIs
{
    public class Price
    {
        public static CesContext Context = new CesContext();
        public int Id { get; set; }
        public string SizeCategory { get; set; }
        public string WeightCategory { get; set; }
        public int CurrentPrice { get; set; }
        public int LatestShippingPrice { get; set; }
        public int LatestTruckingPrice { get; set; }

        public Price(int id, string SizeCategory, string WeightCategory, int CurrentPrice, int LatestShippingPrice,
            int LatestTruckingPrice)
        {
            this.Id = id;
            this.SizeCategory = SizeCategory;
            this.WeightCategory = WeightCategory;
            this.CurrentPrice = CurrentPrice;
            this.LatestShippingPrice = LatestShippingPrice;
            this.LatestTruckingPrice = LatestTruckingPrice;
        }

        public static List<Price> GetPrices()
        {
            var Prices = Context.Pricing;
            List<Price> result = new List<Price>();
            foreach (var item in Prices)
            {
                result.Add(new Price(item.Id, item.SizeCategory, item.WeightCategory, item.Price,
                    item.LatestShippingPrice, item.LatestTruckingPrice));
            }

            return result;
        }

        public static bool UpdatePrice(Price price)
        {
            var update = Context.Pricing.FirstOrDefault(x => x.Id == price.Id);
            if (update == null)
                return false;

            update.SizeCategory = price.SizeCategory;
            update.WeightCategory = price.WeightCategory;
            update.Price = price.CurrentPrice;
            update.LatestShippingPrice = price.LatestShippingPrice;
            update.LatestTruckingPrice = price.LatestTruckingPrice;

            Context.Update(update);
            Context.SaveChanges();
            return true;
        }
    }
}
