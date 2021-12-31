using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.DiscountStrategies
{
    public class TenPercentDiscountOffer : OfferType
    {
        public override Discount GetDiscount(KeyValuePair<Product, double> productQuantity, 
            SupermarketCatalog catalog, 
            Offer offer)
        {
            double quantity = productQuantity.Value;
            Product product = productQuantity.Key;

            return new Discount(product,
                offer.Argument + "% off",
                -quantity * catalog.GetUnitPrice(product) * offer.Argument / 100.0);
        }
    }
}
