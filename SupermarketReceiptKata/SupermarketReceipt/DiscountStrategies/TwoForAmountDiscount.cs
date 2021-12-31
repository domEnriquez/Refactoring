using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.DiscountStrategies
{
    public class TwoForAmountDiscount : OfferType
    {
        public override Discount GetDiscount(KeyValuePair<Product, double> productQuantity, 
            SupermarketCatalog catalog, 
            Offer offer)
        {
            Product product = productQuantity.Key;
            double quantity = productQuantity.Value;
            var quantityAsInt = (int)productQuantity.Value;
            Discount discount = null;

            if (quantityAsInt >= 2)
            {
                var total = offer.Argument 
                    * (quantityAsInt / 2) 
                    + quantityAsInt % 2 
                    * catalog.GetUnitPrice(product);

                var discountN = catalog.GetUnitPrice(product) 
                    * quantity - total;

                discount = new Discount(product, 
                    "2 for " + offer.Argument, 
                    -discountN);
            }

            return discount;
        }
    }
}
